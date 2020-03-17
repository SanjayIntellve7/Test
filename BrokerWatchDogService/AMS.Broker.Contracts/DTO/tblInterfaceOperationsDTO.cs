using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{

    [DataContract()]
    public partial class tblInterfaceOperationsDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceTypeID { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceSubTypeID { get; set; }

        [DataMember()]
        public Nullable<Int32> InterfaceOperationsID { get; set; }

        [DataMember()]
        public String OperationCommand { get; set; }

        [DataMember()]
        public Int32 tblInterfaceOperationsMaster_ID { get; set; }

        [DataMember()]
        public tblInterfaceOperationsMasterDTO tblInterfaceOperationsMasterDTO { get; set; }

        public tblInterfaceOperationsDTO()
        {
        }

        public tblInterfaceOperationsDTO(Int32 iD, Nullable<Int32> interfaceTypeID, Nullable<Int32> interfaceSubTypeID, Nullable<Int32> interfaceOperationsID, String operationCommand, Int32 tblInterfaceOperationsMaster_ID, tblInterfaceOperationsMasterDTO tblInterfaceOperationsMasterDTO)
        {
            this.ID = iD;
            this.InterfaceTypeID = interfaceTypeID;
            this.InterfaceSubTypeID = interfaceSubTypeID;
            this.InterfaceOperationsID = interfaceOperationsID;
            this.OperationCommand = operationCommand;
            this.tblInterfaceOperationsMaster_ID = tblInterfaceOperationsMaster_ID;
            this.tblInterfaceOperationsMasterDTO = tblInterfaceOperationsMasterDTO;
        }
    }
}
