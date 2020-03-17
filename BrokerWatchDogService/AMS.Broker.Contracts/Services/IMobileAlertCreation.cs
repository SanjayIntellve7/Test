using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IMobileAlertCreation // saurabh 08032018
    {
        [OperationContract(Name = "CreateMobileAlert")]
        bool CreateMobileAlert(string AuthToken, string urgency, string severity, string certainty, string note, string lattitude, string longitude, string Address, string retPath, string retVoicenotePath, string retVideoPath, string Imei_No);
    }
}
