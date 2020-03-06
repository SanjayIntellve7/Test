using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.AutherizationServiceTests.ControllerWcfService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AMS.Broker.AutherizationServiceTests
{
    /// <summary>
    /// Contains test methods for Controller Service
    /// </summary>
    [TestClass]
    public class ControllerServiceTests
    {                       
        #region Additional test attributes
        
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddNvr_NewNvr_AddedSuccessfully()
        {
            var controllerServiceClient = new ControllerServiceClient();
            var nvr = new NvrDto
                {
                    IPAddress = "168.63.83.237",
                    Username = "Administrator",
                    Password = "2o2oImaging",
                    Port = 1518,
                    Description = "Test Server",
                    NvrUrl = "http://2020-NVR/guardnvr/mobi/cameras.asp"
                };            
            var nvrAsJson = Serialize(nvr);

            var result = controllerServiceClient.AddNvr(string.Empty, nvrAsJson);
            
            Assert.IsTrue(result);
        }

        private static string Serialize<T>(T graph)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            string jsonCode;

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, graph);
                jsonCode = Encoding.Default.GetString(ms.ToArray());
            }
            return jsonCode;
        }
    }
}
