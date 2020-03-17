using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AMS.Broker.Services;

namespace TestBroker
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AlertsService service = new AlertsService(null,null);
            service.GetAlertsKpi(new Guid("9A7FDF44-AA5E-482A-BAFE-030ACBD01260"), DateTime.MinValue, DateTime.Now);

        }
    }
}
