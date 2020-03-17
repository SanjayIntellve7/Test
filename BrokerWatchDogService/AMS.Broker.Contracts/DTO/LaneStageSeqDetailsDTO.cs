using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class LaneStageSeqDetailsDTO
    {      
        public Dictionary<int, FromLane> fromLaneList { get; set; }
    }
    public class FromLane
    {
        public StageDetails stageDetails { get; set; }
        public int laneNo { get; set; }
        public string LaneFrom { get; set; }
    }
    public class StageDetails
    {
        public Dictionary<int, PhaseDetails> phaseList { get; set; }
        public int stageNo { get; set; }
        public string stageName { get; set; }
    }
    public class PhaseDetails
    {
        //public Dictionary<int, phaseTypeDetails> phaseTypeList { get; set; }
        public string phaseName { get; set; }
        public int phaseNo { get; set; }
        public int phaseSeqNo { get; set; }
        public int phaseType { get; set; }//1-VEHICULAR (STRAIGHT) 2-FILTERGREEN (RIGHT) 3-INDUCTIVE (LEFT)
        public Dictionary<int, LampDetails> phaseLampList { get; set; }
    }
    public class LampDetails
    {
        public int LampNo { get; set; }
        public int LampType { get; set; }//1- Means Red, 2- Means Amber,3 means-Green
    }
}
