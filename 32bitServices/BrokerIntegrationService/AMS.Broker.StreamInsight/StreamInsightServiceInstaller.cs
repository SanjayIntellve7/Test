using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace AMS.Broker.StreamInsight
{
    [RunInstaller(true)]
    public partial class StreamInsightServiceInstaller : Installer
    {
        public StreamInsightServiceInstaller()
        {
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            // MUST RUN AS ADMINISTRATOR FOR WCF TO WORK CORRECTLY 
            // (something to do with registering for http)
            // By setting this value to ServiceAccount.User
            // the installer will prompt for a username / password 
            // during installation
            processInstaller.Account = ServiceAccount.User;

            serviceInstaller.DisplayName = "2020 TouchControll StreamInsight";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.Description = "Provides communication chanell between 2020 TouchControll Server and physical sensors.";


            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "2020 TouchControll StreamInsight";

            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            // auto-start
            ServiceController controller = new ServiceController("2020 TouchControll StreamInsight");
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
