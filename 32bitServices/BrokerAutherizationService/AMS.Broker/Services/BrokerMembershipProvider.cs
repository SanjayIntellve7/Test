using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace AMS.Broker.AutherizationService.Services
{
    public class BrokerMembershipProvider : SqlMembershipProvider
    {
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            // Update the private connection string field in the base class.
            string connectionString = Storage.RhinoConnectionString; //"Server=192.168.0.193;Database=CentralDB_27042017;User Id=sa;Password=sa123;";
            // Set private property of Membership provider.
            FieldInfo connectionStringField = GetType().BaseType.GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
            connectionStringField.SetValue(this, connectionString);
        }
    }
}
