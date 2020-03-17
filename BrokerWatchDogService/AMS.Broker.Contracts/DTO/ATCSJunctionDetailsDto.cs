using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Broker.Contracts.DTO
{
    public class ATCSJunctionDetailsDto
    {
        public string sName { get; set; }
        public string sIntersectionName { get; set; }
        public int nDistanceFromRefJn { get; set; }
        public string tSystemTime { get; set; }
        public int nCurrentStageNo { get; set; }
        public int nCurrentSequenceNo { get; set; }
        public string sMode { get; set; }
        public string sStatus { get; set; }
        public int nStatus { get; set; }
        public int nCurrentCycleNo { get; set; }
        public int nICT { get; set; }
        public int nCCT { get; set; }
        public int nACT { get; set; }
        public int nCycledos { get; set; }
        public double dLatitude { get; set; }
        public double dLongitude { get; set; }
        public List<AlLinkedStageJSON> alLinkedStageJSON { get; set; }
        public List<AlLinkedPhaseJSON> alLinkedPhaseJSON { get; set; }
        public List<AlLinkedDetectorJSON> alLinkedDetectorJSON { get; set; }
        public List<AlPoleJSON> alPoleJSON { get; set; }
        public int nPriorityStageSequence { get; set; }
        public int nUpStreamStageSequenceNo { get; set; }
        public int nDownStreamStageSequenceNo { get; set; }
        public int npriorityEnabled { get; set; }
        public string scosicost_status { get; set; }
        public string sJunctionStateInCorridor { get; set; }
        public string sCosiCostOptimizerMode { get; set; }
        public double nCumulativeVolume { get; set; }
        public int nCumulativeViolations { get; set; }
        public int nOSCycleDOS { get; set; }
        public int nUSCycleDOS { get; set; }
        public int nOffsetWaitingDelayTime { get; set; }
        public List<int> alAllPhaseJSON { get; set; }
        public int nMaxCCT { get; set; }
    }

    public class AlLinkedStageJSON
    {
        public int nSeqno { get; set; }
        public int nStageno { get; set; }
        public int nAvailableGreen { get; set; }
        public int nAllocatedGreen { get; set; }
        public int nUtilizedGreen { get; set; }
        public string tSystemTime { get; set; }
        public int nVehicleCount { get; set; }
        public double dStageVolume { get; set; }
    }

    public class AlLinkedPhaseJSON
    {
        public int nPhaseNo { get; set; }
        public string sPhaseType { get; set; }
        public int iFlashStatus { get; set; }
    }

    public class AlLinkedDetectorJSON
    {
        public int nDetectorNo { get; set; }
        public int bDetectorStatus { get; set; }
    }

    public class AlLinkedLampJSON
    {
        public int nLampNo { get; set; }
        public int bLampStatus { get; set; }
        public string sLampColor { get; set; }
    }

    public class AlPoleJSON
    {
        public int nPoleNo { get; set; }
        public List<AlLinkedLampJSON> alLinkedLampJSON { get; set; }
    }


    public class ATCCorridorMasterDto
    {
        public Int32 ID { get; set; }
        public string CorridorName { get; set; }
        public ATCCorridorMasterDto()
        { }
    }

    public class ATCJunctionMasterDto
    {
        public Int32 ID { get; set; }
        public Int32 CorridorID { get; set; }
        public string JunctionName { get; set; }
        public ATCJunctionMasterDto()
        { }
    }

    public class JunctionRootObject
    {
        public string sName { get; set; }
        public string sIntersectionName { get; set; }
        public int nDistanceFromRefJn { get; set; }
        public string tSystemTime { get; set; }
        public int nCurrentStageNo { get; set; }
        public int nCurrentSequenceNo { get; set; }
        public string sMode { get; set; }
        public string sStatus { get; set; }
        public int nStatus { get; set; }
        public int nCurrentCycleNo { get; set; }
        public int nICT { get; set; }
        public int nCCT { get; set; }
        public int nACT { get; set; }
        public int nCycledos { get; set; }
        public double dLatitude { get; set; }
        public double dLongitude { get; set; }
        public List<AlLinkedStageJSON> alLinkedStageJSON { get; set; }
        public List<AlLinkedPhaseJSON> alLinkedPhaseJSON { get; set; }
        public List<AlLinkedDetectorJSON> alLinkedDetectorJSON { get; set; }
        public List<AlPoleJSON> alPoleJSON { get; set; }
        public int nPriorityStageSequence { get; set; }
        public int nUpStreamStageSequenceNo { get; set; }
        public int nDownStreamStageSequenceNo { get; set; }
        public int npriorityEnabled { get; set; }
        public string scosicost_status { get; set; }
        public string sJunctionStateInCorridor { get; set; }
        public string sCosiCostOptimizerMode { get; set; }
        public double nCumulativeVolume { get; set; }
        public int nCumulativeViolations { get; set; }
        public int nOSCycleDOS { get; set; }
        public int nUSCycleDOS { get; set; }
        public int nOffsetWaitingDelayTime { get; set; }
        public List<int> alAllPhaseJSON { get; set; }
        public int nMaxCCT { get; set; }
    }
}
