using AMS.Broker.Contracts.DTO;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using VideoPlayer;


namespace AMS.Broker.IntegrationService.Services
{
    class Mediaintegration
    {
        public AlertMediaintegration _media = null;
        private System.Timers.Timer _sequenceTimer;
        public NVRServiceAct _nvrServices;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public Mediaintegration()
        {
            _nvrServices = new NVRServiceAct();
            //_nvrServices.Initialize();
        }

        public void CreateGetPhotoTask()
        {
            _sequenceTimer = new System.Timers.Timer(5000);
            _sequenceTimer.Elapsed += _sequenceTimer_Tick;
            var IsEnableExp = Storage.ISExportEnable ;
            if (IsEnableExp == "1")
            {
                _sequenceTimer.Start();
            }
        }

        public void DeleteTempFiles()
        {
            string strPathTemp = Storage.VideoRepository; //System.Configuration.ConfigurationManager.AppSettings["VideoRepository"];
            string strVideoFile = strPathTemp + "\\Temp";
            string strSearchParam = "*.*";
            string[] files = Directory.GetFiles(strVideoFile + "\\", strSearchParam, SearchOption.TopDirectoryOnly);
            int numFiles = files.Length;
            for (int i = 0; i < numFiles; i++)
            {
                string file = files[i].ToString();
                try
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);                       
                    }
                }
                catch (Exception ex)
                {
                    Logger.Info("Mediaintegration DeleteTempFiles() Exception:" + ex.Message);
                    string Message1 = "Mediaintegration-DeleteTempFiles -- Exception = " + ex.Message;
                    //InsertBrokerOperationLog.AddProcessLog(Message1);
                    InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                }
            }
        }
        private void _sequenceTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                _sequenceTimer.Stop();
                
                ////Read all the Image file Tickets and process them
                string strSsa = "";
                string strPath = Storage.AlertMediaTicket;//System.Configuration.ConfigurationManager.AppSettings["AlertMediaTicket"];
                string[] files = Directory.GetFiles(strPath + "\\", "AlertMediaImage_*.tkt", SearchOption.TopDirectoryOnly);
                int numFiles = files.Length;

                for (int i = 0; i < numFiles; i++)
                {
                    string file = files[i].ToString();
                    string contents = File.ReadAllText(file);
                    string[] nIds = contents.Split(',');
                    if (nIds.Length > 0)
                    {
                        try
                        {
                            _media = new AlertMediaintegration(_nvrServices);
                            _media.GetAlertImage(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], file);
                            //Task taskA = Task.Factory.StartNew(() =>  _media.GetAlertImage(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], file));
                            //taskA.Wait();
                            Thread.Sleep(10000);
                        }
                        catch (Exception ex)
                        {
                            Logger.Info("Mediaintegration _sequenceTimer_Tick() Exception:" + ex.Message);

                            string Message1 = "Mediaintegration-_sequenceTimer_Tick -- Exception = " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message1);
                            InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                        }
                    }
                }
                

                ////Read all the PlayBack file Tickets and process them  
                ////Delete all exisitng files from Temp Derectory
                
                DeleteTempFiles();
                string strPathPlyBack = Storage.AlertMediaTicket;//System.Configuration.ConfigurationManager.AppSettings["AlertMediaTicket"];
                string[] filesplayBack = Directory.GetFiles(strPathPlyBack + "\\", "AlertMediaPlayBack_*.tkt", SearchOption.TopDirectoryOnly);
                int numFilesply = filesplayBack.Length;
                
                for (int i = 0; i < numFilesply; i++)
                {
                    string file = filesplayBack[i].ToString();
                    string contents = File.ReadAllText(file);
                    string[] nIds = contents.Split(',');
                    if (nIds.Length > 0)
                    {
                        try
                        {
                            _media = new AlertMediaintegration(_nvrServices);
                            _media.GetAlertPlayBack(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], file);
                            //Task taskA = Task.Factory.StartNew(() =>  _media.GetAlertImage(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], file));
                            Thread.Sleep(10000);
                            while(_media.IsCompleted==false)
                            {
                                int ya = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Info("Mediaintegration _sequenceTimer_Tick() Exception:" + ex.Message);
                            string Message1 = "Mediaintegration-_sequenceTimer_Tick -- Exception 1= " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message1);
                            InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                        }
                    }
                }
                
                ////Read all the IR Attched Caemra Playback file Tickets and process them  
                ////Delete all exisitng files from Temp Derectory
                
                DeleteTempFiles();
                strPathPlyBack = Storage.AlertMediaTicket;//System.Configuration.ConfigurationManager.AppSettings["AlertMediaTicket"];
                filesplayBack = Directory.GetFiles(strPathPlyBack + "\\", "IRCameraPlayBack_*.tkt", SearchOption.TopDirectoryOnly);
                numFilesply = filesplayBack.Length;

                for (int i = 0; i < numFilesply; i++)
                {
                    string file = filesplayBack[i].ToString();
                    string contents = File.ReadAllText(file);
                    string[] nIds = contents.Split(',');
                    if (nIds.Length > 0)
                    {
                        try
                        {
                            _media = new AlertMediaintegration(_nvrServices);
                            _media.GetIRPlayBack(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], nIds[8], file);
                            //Task taskA = Task.Factory.StartNew(() =>  _media.GetAlertImage(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], file));
                            Thread.Sleep(10000);
                            while (_media.IsCompleted == false)
                            {
                                int ya = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Info("Mediaintegration _sequenceTimer_Tick() Exception:" + ex.Message);
                            string Message1 = "Mediaintegration-_sequenceTimer_Tick -- Exception 2= " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message1);
                            InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                        }
                    }
                 
                }

                ////Read all the Bookmark Attched Caemra Playback file Tickets and process them  
                ////Delete all exisitng files from Temp Derectory

                DeleteTempFiles();
                strPathPlyBack = Storage.AlertMediaTicket; //System.Configuration.ConfigurationManager.AppSettings["AlertMediaTicket"];
                filesplayBack = Directory.GetFiles(strPathPlyBack + "\\", "CameraDeviceBookMark_*.tkt", SearchOption.TopDirectoryOnly);
                numFilesply = filesplayBack.Length;

                for (int i = 0; i < numFilesply; i++)
                {
                    string file = filesplayBack[i].ToString();
                    string contents = File.ReadAllText(file);
                    string[] nIds = contents.Split(',');
                    if (nIds.Length > 0)
                    {
                        try
                        {
                            _media = new AlertMediaintegration(_nvrServices);
                            _media.GetBookmarkPlayBack(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], nIds[8], file);
                            //Task taskA = Task.Factory.StartNew(() =>  _media.GetAlertImage(nIds[0], nIds[1], nIds[2], nIds[3], nIds[4], nIds[5], nIds[6], nIds[7], file));
                            Thread.Sleep(10000);
                            while (_media.IsCompleted == false)
                            {
                                int ya = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Info("Mediaintegration _sequenceTimer_Tick() Exception:" + ex.Message);
                            string Message1 = "Mediaintegration-_sequenceTimer_Tick -- Exception 3= " + ex.Message;
                            //InsertBrokerOperationLog.AddProcessLog(Message1);
                            InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                        }
                    }

                }


                _sequenceTimer.Start();
            }
            catch (Exception ex)
            {
                Logger.Info("Mediaintegration _sequenceTimer_Tick() Exception:" + ex.Message);
                string Message1 = "Mediaintegration-_sequenceTimer_Tick -- Exception 4= " + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message1);
                InsertIntegrationLog.AddProcessLogIntegration(Message1);//jatin
                _sequenceTimer.Start();
            }
        }
        
    }
}
