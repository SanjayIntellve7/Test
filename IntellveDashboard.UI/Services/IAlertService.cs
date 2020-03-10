using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Services
{
    public interface IAlertService
    {
        Task<string> GetAlertBifurcationChartAsync(string Datafilter);

        Task<string> GetAlertCloseReasonChartAsync(string Datafilter);
    }
}
