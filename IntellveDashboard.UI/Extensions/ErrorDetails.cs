﻿using Newtonsoft.Json;

namespace IntellveDashboard.UI.Extensions
{
    internal class ErrorDetails
    {
        public ErrorDetails()
        {
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}