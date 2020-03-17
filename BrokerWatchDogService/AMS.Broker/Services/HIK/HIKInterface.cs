using AMS.Broker.Contracts.DTO;
using AMS.Broker.WatchDogService;
using AMS.Broker.WatchDogService.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace AMS.Broker.Services.HIK
{
    public class HIKInterface
    {
        public String strIp { get; set; }
        public int nPort { get; set; }
        public String strUserName { get; set; }
        public String strPassword { get; set; }
       // public MainWindow _MainWindow;
        public System.Threading.Thread devTimeSyncThread;
        public Int32 m_lUserID = -1;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo;
        int _nCo = 1;
        public int _nCount = 0;
        public string HikConnectTime = Storage.HikConnectTime;
        public string ConnectTimeOut = Storage.ConnectionTimeOut;
        public uint _hikContime = 10000;
        public int _ConnectionTimeOut = 10000;
        public int _deviceID = 0;
        public HIKInterface(String _strIp, int _nPort, String _strUserName, String _strPassword,int deviceID)//, int nCount,int nCo)
        {
            strIp = _strIp;
            nPort = _nPort;
            strUserName = _strUserName;
            strPassword = _strPassword;
            _deviceID = deviceID;
          //  _nCount = nCount;           
           // _nCo = nCo;
        }

        public void SyncDeviceTime()
        {
            try
            {
                devTimeSyncThread = new System.Threading.Thread(new System.Threading.ThreadStart(ProcessDevTimeSync));
               // devTimeSyncThread.IsBackground = true;                
                //devTimeSyncThread.SetApartmentState(ApartmentState.STA);
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
                    CHCNetSDK.NET_DVR_Logout_V30(m_lUserID);
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
                //Log time                
               // System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)(() =>
               //{
               //    _MainWindow.LogText.AppendText("\n\n" + DateTime.Now.ToString() + "  Process Hik Cam for Ip " + strIp + " Started ..." + _nCount.ToString());
               //}));
               // OperationLogs.AddLog("Process Hik Cam for Ip " + strIp + " Started ... " + _nCo.ToString() + " " + _nCount.ToString());
                try
                {
                    _ConnectionTimeOut = Int32.Parse(ConnectTimeOut);// *1000;
                }
                catch (Exception ex)
                {
                    InsertBrokerOperationLog.AddProcessLog("Error _ConnectionTimeOut ..." + ex.Message);
                }

                System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                var result = clientSocket.BeginConnect(strIp, 554, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(_ConnectionTimeOut));//TimeSpan.FromSeconds(50));

                if (success)
                {
                    try
                    {
                        _hikContime = uint.Parse(HikConnectTime) * 1000;
                    }
                    catch (Exception ex)
                    {
                    }

                    CHCNetSDK.NET_DVR_SetConnectTime(_hikContime, 1);//10000, 1);
                    Int32 DVRPortNumber = nPort;

                    m_lUserID = CHCNetSDK.NET_DVR_Login_V30(strIp, DVRPortNumber, strUserName, strPassword, ref m_struDeviceInfo);
                    if (m_lUserID == -1)
                    {
                        //Login failed
                        //Log message... strIp Camera login failed  
                        InsertBrokerOperationLog.AddProcessLog(strIp + " :Login failed ...");
                        StopInterface();
                        return;
                    }
                    else
                    {
                        InsertBrokerOperationLog.AddProcessLog(strIp + " :Login Success ...");
                    }
                    CHCNetSDK.NET_DVR_TIME CurTime;
                    CurTime.dwYear = uint.Parse(DateTime.Now.Year.ToString());
                    CurTime.dwMonth = uint.Parse(DateTime.Now.Month.ToString());
                    CurTime.dwDay = uint.Parse(DateTime.Now.Day.ToString());
                    CurTime.dwHour = uint.Parse(DateTime.Now.Hour.ToString());
                    CurTime.dwMinute = uint.Parse(DateTime.Now.Minute.ToString());
                    CurTime.dwSecond = uint.Parse(DateTime.Now.Second.ToString());

                    IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(CurTime));
                    try
                    {
                        // Copy the struct to unmanaged memory.
                        Marshal.StructureToPtr(CurTime, pnt, false);
                        uint _size = (uint)Marshal.SizeOf(CurTime);
                        var IsTimeSet = CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_TIMECFG, 0, pnt, _size);

                        if (IsTimeSet == true)
                        {
                            //Log message......Successfuly Time Sync strIp Camera  
                            try
                            {
                                using (var ctx = new CentralDBEntities())
                                {
                                    var tblDeviceSync = ctx.tblTimeSyncinfo.FirstOrDefault(x => x.DeviceID == _deviceID);
                                    tblDeviceSync.DateTimeSyncStatus = 1;
                                    ctx.Entry(tblDeviceSync).State = System.Data.EntityState.Modified;
                                    ctx.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {                               
                            }
                            InsertBrokerOperationLog.AddProcessLog("Successfuly Time Sync: " + strIp + " Camera ...");
                        }
                        else
                        {
                            //Log message......Failed Time Sync strIp Camera  .
                            try
                            {
                                using (var ctx = new CentralDBEntities())
                                {
                                    var tblDeviceSync = ctx.tblTimeSyncinfo.FirstOrDefault(x => x.DeviceID == _deviceID);
                                    tblDeviceSync.DateTimeSyncStatus = 0;
                                    ctx.Entry(tblDeviceSync).State = System.Data.EntityState.Modified;
                                    ctx.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            InsertBrokerOperationLog.AddProcessLog("Failed Time Sync: " + strIp + " Camera ...");
                        }
                        StopInterface();
                        clientSocket.EndConnect(result);
                    }
                    catch (Exception ex)
                    {
                        InsertBrokerOperationLog.AddProcessLog("Error  ProcessDevTimeSync NET_DVR_SetDVRConfig ..." + ex.Message);
                    }
                    finally
                    {
                        // Free the unmanaged memory.
                        Marshal.FreeHGlobal(pnt);
                    }

                }
                else
                {
                    InsertBrokerOperationLog.AddProcessLog(strIp + " :Camera is offline");
                    //Log message... strIp Camera is offline
                }
            }
            catch (Exception ex)
            {
                InsertBrokerOperationLog.AddProcessLog("Error  ProcessDevTimeSync ..." + ex.Message);
                MessageBox.Show("Error  ProcessDevTimeSync ..." + ex.Message);
            }
                       

            //System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            //{
            //    _MainWindow.LogText.AppendText("\n\n" + DateTime.Now.ToString() + "  Process Hik Cam for Ip " + strIp + " End ..." + _nCount.ToString());
            //}));

           // OperationLogs.AddLog("Process Hik Cam for Ip " + strIp + " End ... " + _nCo.ToString() + " "  + _nCount.ToString());
        }

    }
}
