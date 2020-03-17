using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    [DataContract()]
    public partial class tblSOPActionDataMasterDTO
    {
        [DataMember()]
        public Int32 ID { get; set; }

        [DataMember()]
        public Int32 ActionId { get; set; }

        [DataMember()]
        public Boolean ShowIcon { get; set; }

        [DataMember()]
        public Boolean ShowComment { get; set; }

        [DataMember()]
        public Boolean ShowHelp { get; set; }

        [DataMember()]
        public Boolean ShowStepValidation { get; set; }

        [DataMember()]
        public Boolean ShowStepType { get; set; }

        [DataMember()]
        public Boolean ShowToDo { get; set; }

        [DataMember()]
        public Boolean ShowDeviceTypeList { get; set; }

        [DataMember()]
        public Boolean ShowDeviceList { get; set; }

        [DataMember()]
        public Boolean ShowSite { get; set; }

        [DataMember()]
        public Boolean ShowArea { get; set; }

        [DataMember()]
        public Boolean ShowFloor { get; set; }

        [DataMember()]
        public Boolean ShowZone { get; set; }

        [DataMember()]
        public Boolean ShowStationList { get; set; }

        [DataMember()]
        public Boolean ShowSeverity { get; set; }

        [DataMember()]
        public Boolean ShowUrgency { get; set; }

        [DataMember()]
        public Boolean ShowCertainity { get; set; }

        [DataMember()]
        public Boolean EmailFlag { get; set; }

        [DataMember()]
        public Boolean AdditionalDataFlag { get; set; }

        [DataMember()]
        public Boolean PhoneNoFlag { get; set; }

        [DataMember()]
        public Boolean PredefinedMsgFlag { get; set; }

        [DataMember()]
        public Boolean PredefinedVoiceFlag { get; set; }

        [DataMember()]
        public Boolean VideoWallDisplay { get; set; }

        [DataMember()]
        public Boolean VideoWallSource { get; set; }

        [DataMember()]
        public Boolean PredefinedImage { get; set; }

        [DataMember()]
        public Boolean ShowRefSOP { get; set; }
        

        

        public tblSOPActionDataMasterDTO()
        {
        }

        public tblSOPActionDataMasterDTO(Int32 iD, Int32 actionId, Boolean showIcon, Boolean showComment, Boolean showHelp, Boolean showStepValidation, Boolean showStepType, Boolean showToDo, Boolean showDeviceTypeList, Boolean showDeviceList, Boolean showSite, Boolean showArea, Boolean showFloor, Boolean showZone, Boolean showStationList, Boolean showSeverity, Boolean showUrgency, Boolean showCertainity, Boolean emailFlag, Boolean additionalDataFlag, Boolean phoneNoFlag, Boolean predefinedMsgFlag, Boolean predefinedVoiceFlag, Boolean videoWallDisplay, Boolean videoWallSource, Boolean predefinedImage, Boolean showRefSOP)
        {
            this.ID = iD;
            this.ActionId = actionId;
            this.ShowIcon = showIcon;
            this.ShowComment = showComment;
            this.ShowHelp = showHelp;
            this.ShowStepValidation = showStepValidation;
            this.ShowStepType = showStepType;
            this.ShowToDo = showToDo;
            this.ShowDeviceTypeList = showDeviceTypeList;
            this.ShowDeviceList = showDeviceList;
            this.ShowSite = showSite;
            this.ShowArea = showArea;
            this.ShowFloor = showFloor;
            this.ShowZone = showZone;
            this.ShowStationList = showStationList;
            this.ShowSeverity = showSeverity;
            this.ShowUrgency = showUrgency;
            this.ShowCertainity = showCertainity;
            this.EmailFlag = emailFlag;
            this.AdditionalDataFlag = additionalDataFlag;
            this.PhoneNoFlag = phoneNoFlag;
            this.PredefinedMsgFlag = predefinedMsgFlag;
            this.PredefinedVoiceFlag = predefinedVoiceFlag;
            this.VideoWallSource = videoWallSource;
            this.VideoWallDisplay = VideoWallDisplay;
            this.PredefinedImage = predefinedImage;
            this.ShowRefSOP = showRefSOP;
        }
    }
}
