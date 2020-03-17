using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSOPStepDataDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Int32 StepId { get; set; }

        [DataMember()]
        public String Name { get; set; }

        [DataMember()]
        public Int32 SOPId { get; set; }

        [DataMember()]
        public Int32 ActionId { get; set; }

        [DataMember()]
        public Int32 IconID { get; set; }

        [DataMember()]
        public String Comment { get; set; }

        [DataMember()]
        public String Help { get; set; }

        [DataMember()]
        public Nullable<Boolean> StepValidation { get; set; }

        [DataMember()]
        public Nullable<Boolean> StepType { get; set; }

        [DataMember()]
        public String ToDoComment { get; set; }

        [DataMember()]
        public String DeviceTypeList { get; set; }

        [DataMember()]
        public String DeviceList { get; set; }

        [DataMember()]
        public String SiteList { get; set; }

        [DataMember()]
        public String AreaList { get; set; }

        [DataMember()]
        public String FloorList { get; set; }

        [DataMember()]
        public String ZoneList { get; set; }

        [DataMember()]
        public String StationList { get; set; }

        [DataMember()]
        public String SeverityList { get; set; }

        [DataMember()]
        public String UrgencyList { get; set; }

        [DataMember()]
        public String CertainityList { get; set; }

        [DataMember()]
        public String EmailData { get; set; }

        [DataMember()]
        public String PhnoData { get; set; }

        [DataMember()]
        public String AdditionalData { get; set; }

        [DataMember()]
        public String PredefinedMsgData { get; set; }

        [DataMember()]
        public String PredefinedVoiceData { get; set; }

        [DataMember()]
        public String VideoWallDisplay { get; set; }

        [DataMember()]
        public String VideoWallSource { get; set; }

        [DataMember()]
        public String PredefinedImage { get; set; }

        [DataMember()]
        public Int32 RefSOP { get; set; }
        

        public tblSOPStepDataDTO()
        {
        }

        public tblSOPStepDataDTO(Int32 iD, Int32 stepId, String name, Int32 sOPId, Int32 actionId, Int32 iconId, String comment, String help, Nullable<Boolean> stepValidation, Nullable<Boolean> stepType, String toDoComment, String deviceTypeList, String deviceList, String siteList, String areaList, String floorList, String zoneList, String stationList, String severityList, String urgencyList, String certainityList, String emailData, String phnoData, String additionalData, String predefinedMsgData, String predefinedVoiceData, String videoWallDisplay, String videoWallSource, String predefinedImage, Int32 refSOP)
        {
            this.ID = iD;
            this.StepId = stepId;
            this.Name = name;
            this.SOPId = sOPId;
            this.ActionId = actionId;
            this.IconID = iconId;
            this.Comment = comment;
            this.Help = help;
            this.StepValidation = stepValidation;
            this.StepType = stepType;
            this.ToDoComment = toDoComment;
            this.DeviceTypeList = deviceTypeList;
            this.DeviceList = deviceList;
            this.SiteList = siteList;
            this.AreaList = areaList;
            this.FloorList = floorList;
            this.ZoneList = zoneList;
            this.StationList = stationList;
            this.SeverityList = severityList;
            this.UrgencyList = urgencyList;
            this.CertainityList = certainityList;
            this.EmailData = emailData;
            this.PhnoData = phnoData;
            this.AdditionalData = additionalData;
            this.PredefinedMsgData = predefinedMsgData;
            this.PredefinedVoiceData = predefinedVoiceData;
            this.VideoWallSource = videoWallSource;
            this.VideoWallDisplay = videoWallDisplay;
            this.PredefinedImage = predefinedImage;
            this.RefSOP = refSOP;
        }
    }
}
