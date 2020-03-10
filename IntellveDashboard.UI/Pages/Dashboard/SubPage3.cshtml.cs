using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CustomLogContracts;
using IntellveDashboard.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IntellveDashboard.UI.Pages.Dashboard
{
    public class SubPage3Model : PageModel
    {
        [BindProperty]
        public List<DeviceTypeFilter> deviceTypeFilter { get; set; }

        [BindProperty]
        public List<OperatorFilter> OperatorFilter { get; set; }

        [BindProperty]
        public List<BranchFilter> branchFilter { get; set; }

        private readonly IOptions<ConfigSettingsModel> _settings;

        private readonly ILoggerManager _logger;

        public SubPage3Model(IOptions<ConfigSettingsModel> settings, ILoggerManager logger)
        {
            _settings = settings;
            _logger = logger;
        }

        public void OnGet()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    _logger.LogInfo("GetDeviceTypes");
                    var endPoint = _settings.Value.web_API_SERVICE_HOSTS.dashboard_WEB_API_HOST + "/api/Dashboard/GetDeviceTypes";
                    var json = client.GetStringAsync(endPoint).Result;

                    json = json.Replace(@"\", string.Empty).Trim('"');
                    var deviceType = JsonConvert.DeserializeObject<DeviceTypeRootObject>(json);

                    deviceTypeFilter = (from j in deviceType.DeviceTypes select new DeviceTypeFilter() { Text = j.Description.ToString(), Value = j.Description }).ToList();

                }
                catch (Exception ex)
                {
                    _logger.LogError("GetDeviceTypes Error is :" + ex.Message);
                }
            }

            using (var client = new HttpClient())
            {
                try
                {
                    _logger.LogInfo("GetBranches");

                    var endPoint = _settings.Value.web_API_SERVICE_HOSTS.dashboard_WEB_API_HOST + "/api/Dashboard/GetBranches";
                    var json = client.GetStringAsync(endPoint).Result;

                    json = json.Replace(@"\", string.Empty).Trim('"');
                    var branch = JsonConvert.DeserializeObject<BranchRootObject>(json);

                    branchFilter = (from j in branch.Branches select new BranchFilter() { Text = j.BranchId.ToString(), Value = j.BranchId }).ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError("GetBranches Error is :" + ex.Message);
                }
            }

            using (var client = new HttpClient())
            {
                try
                {
                    _logger.LogInfo("GetOperators");

                    var endPoint = _settings.Value.web_API_SERVICE_HOSTS.dashboard_WEB_API_HOST + "/api/Dashboard/GetOperators";
                    var json = client.GetStringAsync(endPoint).Result;

                    json = json.Replace(@"\", string.Empty).Trim('"');
                    var operators = JsonConvert.DeserializeObject<OperatorRootObject>(json);

                    OperatorFilter = (from j in operators.Operators select new OperatorFilter() { Text = j.Name.ToString(), Value = j.Name }).ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError("GetOperators Error is :" + ex.Message);
                }
            }
        }
    }
}