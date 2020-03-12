using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mirasys.Clients.Gateway.SDK.Core;
using Mirasys.Clients.Gateway.SDK.Events;
using Mirasys.Clients.Gateway.SDK.Recorder.MediaExport;
using Mirasys.Clients.Gateway.SDK.Recorder.Streaming;
using System.Runtime.InteropServices;
using System.Configuration;
using Mirasys.Clients.Gateway.SDK.Recorder.Alarm;
using Mirasys.Clients.Gateway.SDK.Utils;
using System.Windows;
using Mirasys.Clients.Gateway.SDK.Recorder.Profile;
using Mirasys.Clients.Gateway.SDK.Recorder.RecorderEvent;
using System.Windows.Forms;

namespace MirasysVCAInt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GatewayConnection _connection;
        private static readonly string TestSDKApplicationCode = ConfigurationManager.AppSettings.Get("ApplicationCode");
        private static readonly string MirasysHostIP = ConfigurationManager.AppSettings.Get("MirasysHostIP");
        private static readonly string MirasysHostPort = ConfigurationManager.AppSettings.Get("MirasysHostPort");
        private static readonly string MirasysHostUserName = ConfigurationManager.AppSettings.Get("MirasysHostUserName");
        private static readonly string MirasysHostPassword = ConfigurationManager.AppSettings.Get("MirasysHostPassword");

        private static readonly string PublicApiUrl = ConfigurationManager.AppSettings.Get("PublicApiUrl");
        private static readonly string LicenseKey = ConfigurationManager.AppSettings.Get("LicenseKey");
        int ncount = 0;
        public Dictionary<int, MirasysVaInterface> _MirsyssInterface = new Dictionary<int, MirasysVaInterface>();
       
        public MainWindow()
        {
            InitializeComponent();           
           
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
        }

       

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //
                MirasysVaInterface _MirasysVaInterface = new MirasysVaInterface(TestSDKApplicationCode, MirasysHostIP, MirasysHostPort, MirasysHostUserName, MirasysHostPassword, PublicApiUrl, LicenseKey,this);
                ncount++;
                _MirsyssInterface.Add(ncount, _MirasysVaInterface);
                System.Windows.Controls.Grid InterfaceGrid = new System.Windows.Controls.Grid();
                InterfaceGrid.Visibility = Visibility.Collapsed;
                InterfaceGrid.Children.Add(_MirasysVaInterface);
                RootElement.Children.Add(InterfaceGrid);
                //
            }
            catch (Exception ex)
            {
            }
        }

        //public string getCamDeviceList()
        //{
        //    string strResponce = "";
        //    try
        //    {
        //        //foreach (var _mirasys in MirasysVaInterface)
        //        //{
        //        //    try
        //        //    {
        //        //        strResponce = _mirasys.Value.getCamDeviceList();
        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return string.Empty;
        //}
       
        public void Dispose()
        {
            try
            {

                InsertLog.AddLog("MirasysVCAInterfaceService Dispose()");

                try
                {
                    foreach (var _Obj in _MirsyssInterface)
                    {
                        _Obj.Value.Dispose();
                    }
                }
                catch (Exception ex)
                {
                }
                _MirsyssInterface.Clear();
            }
            catch (Exception ex)
            {
            }
        }
       
        void MainWindow_Closed(object sender, EventArgs e)
        {
            try
            {
                Dispose();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
