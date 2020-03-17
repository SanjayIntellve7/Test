using System;
using System.Configuration.Install;
using System.ComponentModel;
using System.ServiceProcess;

namespace AMS.Broker.WatchDogService
{
    [RunInstaller(true)]
    public class BrokerServiceInstaller : Installer
    {
        public BrokerServiceInstaller()
        {
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            // MUST RUN AS ADMINISTRATOR FOR WCF TO WORK CORRECTLY 
            // (something to do with registering for http)
            // By setting this value to ServiceAccount.User
            // the installer will prompt for a username / password 
            // during installation
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.DisplayName = "2020BrokerWatchDogService";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.Description = "I3OP Server,Its a main server for 2020 platform.";


            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "2020BrokerWatchDogService";

            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            // auto-start
            ServiceController controller = new ServiceController("2020BrokerWatchDogService");
            try
            {
                controller.Start();
            }
            catch (Exception)
            {
                // failed to start the Service automatically
            }
        }
    }
}
