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
    public class BifurcationChart : ViewComponent
    {
        private IAlertService _alertService; 
        public BifurcationChart(IAlertService alertService )
        {
            _alertService = alertService; 
        }
        public async Task<IViewComponentResult> InvokeAsync(string Datafilter)
        {
            var datapoints = await _alertService.GetAlertBifurcationChartAsync(Datafilter);
            ViewBag.BifurcationDatapointsArray = datapoints;
            return View();
        }
    }
}
