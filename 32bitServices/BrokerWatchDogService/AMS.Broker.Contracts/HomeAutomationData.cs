using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts
{
    public class HomeAutomationData
    {
        public string projectname { get; set; }
        //  public string pnooftowers { get; set; }
        public string projectaddress { get; set; }
        //   public string projectpincode { get; set; }
        //   public string projectcountry { get; set; }
        //   public string projectstate { get; set; }
        //  public string projectlocation { get; set; }
        //   public string blockname { get; set; }
        //  public string bnooftowers { get; set; }
        ///  public string noofvillas { get; set; }
        public string towername { get; set; }
        // public string nooffloor { get; set; }
        public string propertyno { get; set; }
        public string propertytype { get; set; }
        public string propertyname { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string cid { get; set; }
        public string devicename { get; set; }
        // public string propertyfloor { get; set; }
        //  public string streetname { get; set; }
        //  public string address { get; set; }
        //  public string propertypincode { get; set; }
        //  public string deviceid { get; set; }
        public string deviceserialnumber { get; set; }
        public string recflag { get; set; }
        public string recstatusflag { get; set; }

        public string title { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string contactnumber { get; set; }
        public string emailid { get; set; }
        public string ownership { get; set; }

    }
}