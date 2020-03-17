using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.Broker.Services.CPPlusDahua
{
    public class CPPlusDahuaInterface
    {
        public String strIp { get; set; }
        public int nPort { get; set; }
        public String strUserName { get; set; }
        public String strPassword { get; set; }

        public System.Threading.Thread devTimeSyncThread;
        public Int32 m_lUserID = -1;

        public CPPlusDahuaInterface(String _strIp, int _nPort, String _strUserName, String _strPassword)
        {
            strIp = _strIp;
            nPort = _nPort;
            strUserName = _strUserName;
            strPassword = _strPassword;
        }

        public void SyncDeviceTime()
        {
            try
            {
                devTimeSyncThread = new System.Threading.Thread(new System.Threading.ThreadStart(ProcessDevTimeSync));
                devTimeSyncThread.IsBackground = true;
                devTimeSyncThread.SetApartmentState(ApartmentState.STA);
                devTimeSyncThread.Start();
            }
            catch (Exception ex)
            {
            }
        }
        public void StopInterface()
        {
            try
            {               
                if (m_lUserID >= 0)
                {
                    CPPlusDahuaSDK.CLIENT_Logout(m_lUserID);
                }               
                m_lUserID = -1;
            }
            catch (Exception ex)
            {
                //InsertLog.AddProcessLog("Exception in StopInterface(): " + ex.Message);
            }
        }
        public void ProcessDevTimeSync()
        {
            try
            {
                System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                var result = clientSocket.BeginConnect(strIp, 554, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
                clientSocket.EndConnect(result);
                if (success)
                {
                   
                    try
                    {
                        CPPlusDahuaSDK.NET_DEVICEINFO deviceInfo;
                        int error = 0;
                        CPPlusDahuaSDK.CLIENT_SetConnectTime(10000, 1);
                        ushort DVRPortNumber =(ushort)nPort;//37777
                     
                        m_lUserID = CPPlusDahuaSDK.CLIENT_Login(strIp, DVRPortNumber, strUserName, strPassword, out deviceInfo, out error);
                        if (m_lUserID == -1)
                        {
                            //Login failed
                            //Log message... strIp Camera login failed  

                            StopInterface();
                            return;
                        }
                        CPPlusDahuaSDK.LPNET_TIME CurTime;
                        CurTime.dwYear = uint.Parse(DateTime.Now.Year.ToString());
                        CurTime.dwMonth = uint.Parse(DateTime.Now.Month.ToString());
                        CurTime.dwDay = uint.Parse(DateTime.Now.Day.ToString());
                        CurTime.dwHour = uint.Parse(DateTime.Now.Hour.ToString());
                        CurTime.dwMinute = uint.Parse(DateTime.Now.Minute.ToString());
                        CurTime.dwSecond = uint.Parse(DateTime.Now.Second.ToString());

                        var IsTimeSet = CPPlusDahuaSDK.CLIENT_SetupDeviceTime(m_lUserID, CurTime);
                        
                        if (IsTimeSet == true)
                        {
                            //Log message......Successfuly Time Sync strIp Camera  
                        }
                        else
                        {
                            //Log message......Failed Time Sync strIp Camera  
                        }
                        StopInterface();
                    }
                    catch (Exception ex)
                    {
                    }                                 

                }
                else
                {
                    //Log message... strIp Camera is offline
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
