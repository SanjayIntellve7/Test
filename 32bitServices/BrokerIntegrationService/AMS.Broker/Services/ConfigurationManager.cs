using System;
using System.Threading;
using QL.Configuration;
using QL.Configuration.Settings;

namespace AMS.Broker.IntegrationService.Services
{
    public class ConfigurationManager : IConfigurationManager
    {
        private MultiserverControllerSettings settings;

        public ConfigurationManager()
        {
            this.settings = new MultiserverControllerSettings()
            {
                Revision = new Guid()
            };
        }

        public event EventHandler<GetSettingsCompletedEventArgs> GetSettingsCompleted;
        public event EventHandler<UpdateSettingsCompletedEventArgs> UpdateSettingsCompleted;

        public void GetSettingsAsync(string typeFullName, object userState)
        {
            var typeName = typeof(MultiserverControllerSettings).FullName;
            if (StringComparer.Ordinal.Compare(typeName, typeFullName) == 0)
            {
                var e = new GetSettingsCompletedEventArgs(null, false, userState, settings);
                var handler = this.GetSettingsCompleted;
                ThreadPool.QueueUserWorkItem(_ => handler(this, e));
            }
            else
            {
                throw new ArgumentException("This example supports only MultiserverControllerSettings.", "typeFullName");
            }
        }

        public void UpdateSettingsAsync(SettingsBase settings, object userState)
        {
            if (settings.GetType() == typeof(MultiserverControllerSettings))
            {
                this.settings = (MultiserverControllerSettings)settings;
                var e = new UpdateSettingsCompletedEventArgs(null, false, userState, settings, typeof(MultiserverControllerSettings));
                var handler = this.UpdateSettingsCompleted;
                ThreadPool.QueueUserWorkItem(_ => handler(this, e));
            }
            else
            {
                throw new ArgumentException("This example supports only MultiserverControllerSettings.", "typeFullName");
            }
        }

    }
}
