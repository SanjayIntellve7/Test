using IntellveDashboard.UI.Models;
using IntellveDashboard.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Components
{
    public class CloseReasonChart : ViewComponent
    {
        private IAlertService _alertService;

        public CloseReasonChart(IAlertService alertService )
        {
            _alertService = alertService; 
        }
        public async Task<IViewComponentResult> InvokeAsync(string Datafilter)
        {
            var datapoints = await _alertService.GetAlertCloseReasonChartAsync(Datafilter);
            ViewBag.CloseReasonDatapointsArray = datapoints;
            return View();
        }
    }
}
