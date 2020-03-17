using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblIOTTXDataDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public String DeviceID { get; set; }

        [DataMember()]
        public Nullable<DateTime> TxDateTime { get; set; }

        [DataMember()]
        public String EnergyMeterName { get; set; }

        [DataMember()]
        public Nullable<Int32> EV1N { get; set; }

        [DataMember()]
        public Nullable<Int32> EV2N { get; set; }

        [DataMember()]
        public Nullable<Int32> EV3N { get; set; }

        [DataMember()]
        public Nullable<Int32> EPowerfactor { get; set; }

        [DataMember()]
        public Nullable<Int32> Efrequency { get; set; }

        [DataMember()]
        public Nullable<Int32> EkWh { get; set; }

        [DataMember()]
        public String GasMeterName { get; set; }

        [DataMember()]
        public Nullable<Int32> GTotalliser { get; set; }

        [DataMember()]
        public String WaterMeterName { get; set; }

        [DataMember()]
        public Nullable<Int32> WTotaliser { get; set; }

        [DataMember()]
        public String IODeviceName { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD1 { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD2 { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD3 { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD4 { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD5 { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD6 { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD7 { get; set; }

        [DataMember()]
        public Nullable<Boolean> IOD8 { get; set; }

        public tblIOTTXDataDTO()
        {
        }

        public tblIOTTXDataDTO(Int32 iD, String deviceID, Nullable<DateTime> txDateTime, String energyMeterName, Nullable<Int32> eV1N, Nullable<Int32> eV2N, Nullable<Int32> eV3N, Nullable<Int32> ePowerfactor, Nullable<Int32> efrequency, Nullable<Int32> ekWh, String gasMeterName, Nullable<Int32> gTotalliser, String waterMeterName, Nullable<Int32> wTotaliser, String iODeviceName, Nullable<Boolean> iOD1, Nullable<Boolean> iOD2, Nullable<Boolean> iOD3, Nullable<Boolean> iOD4, Nullable<Boolean> iOD5, Nullable<Boolean> iOD6, Nullable<Boolean> iOD7, Nullable<Boolean> iOD8)
        {
            this.ID = iD;
            this.DeviceID = deviceID;
            this.TxDateTime = txDateTime;
            this.EnergyMeterName = energyMeterName;
            this.EV1N = eV1N;
            this.EV2N = eV2N;
            this.EV3N = eV3N;
            this.EPowerfactor = ePowerfactor;
            this.Efrequency = efrequency;
            this.EkWh = ekWh;
            this.GasMeterName = gasMeterName;
            this.GTotalliser = gTotalliser;
            this.WaterMeterName = waterMeterName;
            this.WTotaliser = wTotaliser;
            this.IODeviceName = iODeviceName;
            this.IOD1 = iOD1;
            this.IOD2 = iOD2;
            this.IOD3 = iOD3;
            this.IOD4 = iOD4;
            this.IOD5 = iOD5;
            this.IOD6 = iOD6;
            this.IOD7 = iOD7;
            this.IOD8 = iOD8;
        }
    }
}
