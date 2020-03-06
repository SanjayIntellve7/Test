using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Activation;
using System.Xml;
using System.Reflection;
using System.IO;
using System.ServiceModel.Web;

namespace AMS.Broker.AutherizationService
{

    [ServiceContract]
    public interface ICrossDomainService
    {
        [OperationContract]
        [WebGet(UriTemplate = "ClientAccessPolicy.xml")]
        Message ProvidePolicyFile();

    }


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CrossDomainService : ICrossDomainService
    {
        public Message ProvidePolicyFile()
        {

            // great article
            // http://www.dotnetcurry.com/ShowArticle.aspx?ID=208


            // Either specify ClientAccessPolicy.xml file path properly
            // or put that in \Bin folder of the console application

            //FileStream filestream = File.Open(@"ClientAccessPolicy.xml", FileMode.Open);
            //XmlReader reader = XmlReader.Create(filestream);
            //Message result = Message.CreateMessage(MessageVersion.None, "", reader);

            // Embed file as Resource otherwise the ClientAccessPolicy.xml file has to be 
            // in the windows system folder (c:\windows\system32) because that's where svchost.exe--the windows service host wrapper--is.
            // XmlReader reader = XmlReader.Create(@"ClientAccessPolicy.xml");
            // Message result = Message.CreateMessage(MessageVersion.None, "", reader);



            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream xmlStream = assembly.GetManifestResourceStream("PCRService.ClientAccessPolicy.xml");
            XmlReader reader = System.Xml.XmlReader.Create(xmlStream);
            Message result = System.ServiceModel.Channels.Message.CreateMessage(System.ServiceModel.Channels.MessageVersion.None, "", reader);


            return result;


        }
    }
}
