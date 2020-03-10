using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IntellveDashboard.UI.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            //string strRetVal = "";
            //List<DataPoint> dataPoints = new List<DataPoint>();
            //using (var client = new HttpClient())
            //{
            //    var response = await client.GetAsync(new Uri(_settings.ApiHostAddress + "/api/Alerts/GetAlertsSummary"));
            //    if (response.IsSuccessStatusCode)
            //        strRetVal = response.Content.ReadAsStringAsync().Result;
            //}
            //var data = StringExtensions.clean(strRetVal);
            //var result = JsonConvert.DeserializeObject<AlertSummaryChartDataModel>(data);

            //dataPoints = result.chartData
            //            .GroupBy(l => l.yearmonthday.year)
            //            .Select(cl => new DataPoint(Convert.ToDouble(cl.Sum(c => c.Count)), Convert.ToString(cl.Key))).ToList();
            //ViewBag.AlertsSummary = JsonConvert.SerializeObject(dataPoints);

            //dataPoints = new List<DataPoint>();
            //dataPoints = result.chartData
            //            .Where(l => l.yearmonthday.year == 2019)
            //            .GroupBy(l => l.yearmonthday.month)
            //            .Select(cl => new DataPoint(Convert.ToDouble(cl.Key), Convert.ToDouble(cl.Sum(c => c.Count)))).ToList();
            //ViewBag.Alerts2019Summary = JsonConvert.SerializeObject(dataPoints);

            //dataPoints = new List<DataPoint>();
            //dataPoints = result.chartData
            //            .Where(l => l.yearmonthday.year == 2018)
            //            .GroupBy(l => l.yearmonthday.month)
            //            .Select(cl => new DataPoint(Convert.ToDouble(cl.Key), Convert.ToDouble(cl.Sum(c => c.Count)))).ToList();
            //ViewBag.Alerts2018Summary = JsonConvert.SerializeObject(dataPoints);

            return View();
        }  
    }
}