using IntellveDashboard.UI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Services
{
    public class AlertService : IAlertService
    {


        private readonly IOptions<ConfigSettingsModel> _settings;
        public AlertService(IOptions<ConfigSettingsModel> settings)
        {
            _settings = settings;
        }
        public async Task<string> GetAlertBifurcationChartAsync(string Datafilter)
        {
            using (var client = new HttpClient())
            {
                var endPoint = _settings.Value.web_API_SERVICE_HOSTS.dashboard_WEB_API_HOST + "/api/Dashboard/GetAlertCountBifurcation?Datafilter="+ Datafilter;
                var json = await client.GetStringAsync(endPoint);
                return JsonConvert.DeserializeObject<string>(json);
            }
        }
        public async Task<string> GetAlertCloseReasonChartAsync(string Datafilter)
        {
            using (var client = new HttpClient())
            {
                var endPoint = _settings.Value.web_API_SERVICE_HOSTS.dashboard_WEB_API_HOST + "/api/Dashboard/GetAlertCountBasedOnCloseReason?Datafilter" + Datafilter;
                var json = await client.GetStringAsync(endPoint);
                return JsonConvert.DeserializeObject<string>(json);
            }
        }
    }
}
