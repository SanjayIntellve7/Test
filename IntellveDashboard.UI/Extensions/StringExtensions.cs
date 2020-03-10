using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntellveDashboard.UI.Extensions
{
    public static class StringExtensions
    {
        public static string clean(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            sb.Replace(";", "");
            sb.Replace("(", "");
            sb.Replace(")", "");
            sb.Replace(@"\", string.Empty);
            sb.Replace("\"", string.Empty);
            return sb.ToString().ToLower();
        }
    }
}
