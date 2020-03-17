using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Logica.RealTimeDataMgmt.Hosting;
using System.ServiceModel;
using NLog;

namespace AMS.Broker.WatchDogService.StreamInsight
{
    partial class StreamInsightService : ServiceBase
    {
        public StreamInsightService()
        {
            this.ServiceName = "2020 TouchControll StremInsight";
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
        }

        protected override void OnStart(string[] args)
        {
            QueryHost.Initialize<InProcessQueryHost>(true);
            QueryHost.Current.Start();

            var controllerHost = new ServiceHost(QueryHost.Current);
            controllerHost.Open();
        }
        protected override void OnStop()
        {
            QueryHost.Shutdown();
        }

        public void StartInConsole(string[] args)
        {
            this.OnStart(args);
        }
        public void StopInConsole()
        {
            this.OnStop();
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (e.ExceptionObject as Exception);

            ExceptionHandler(exception);
        }
        private void ExceptionHandler(Exception exception)
        {
            if (exception != null)
                _logger.Fatal(exception.Message);
        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();
    }
}
