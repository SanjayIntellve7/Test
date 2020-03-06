using System;
using System;
using System.Threading;
using QL.Configuration;
using QL.Configuration.Settings;

namespace AMS.Broker.IntegrationService.Services
{
    public class ConfigurationManagerStub : IConfigurationManager
    {
        private MultiserverControllerSettings settings = new MultiserverControllerSettings
        {
            Revision = new Guid()
        };

        public void UpdateSettingsAsync(SettingsBase settings, object userState)
        {
            this.settings = (MultiserverControllerSettings)settings;
            var e = new UpdateSettingsCompletedEventArgs(null, false, userState, settings, typeof(MultiserverControllerSettings));
            var handler = this.UpdateSettingsCompleted;
            ThreadPool.QueueUserWorkItem(_ => handler(this, e));
        }

        public void GetSettingsAsync(string typeFullName, object userState)
        {
            var e = new GetSettingsCompletedEventArgs(null, false, userState, settings);
            var handler = this.GetSettingsCompleted;
            ThreadPool.QueueUserWorkItem(_ => handler(this, e));
        }

        public event EventHandler<GetSettingsCompletedEventArgs> GetSettingsCompleted;
        public event EventHandler<UpdateSettingsCompletedEventArgs> UpdateSettingsCompleted;
    }
}