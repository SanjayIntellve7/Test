using QL.Communication.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AMS.Broker.IntegrationService.Services
{
    public class AdditionalCameraInfoRequest : MessageBase
    {
        public override void Serialize(IPropertyBag propertyBag)
        {

            base.Serialize(propertyBag);
            propertyBag["action"] = "executeinscript";
            propertyBag["command"] = "get_cameras_info";


        }
    }
}

