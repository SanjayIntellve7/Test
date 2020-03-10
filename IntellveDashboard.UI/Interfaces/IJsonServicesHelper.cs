using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Interfaces
{
    public interface IJsonServicesHelper
    { 
        string GetSerivcePath(string serviceName, string method, params string[] parameters);
    }
}
