using AMS.Broker.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
namespace AMS.Broker.Contracts.Services
{
    [ServiceContract]
    public interface IGeoTrackingService
    {
        [OperationContract]
        Stream ConsumeAlert(GeoTrackingData EventData);

        [OperationContract]
        string InputMessage();

        [OperationContract]
        string Deviceregistration();

        [OperationContract]
        string SubmitFencingDetails();

        [OperationContract]
        IEnumerable<tblDeviceGeoTrackHistoryDTO> GetDeviceFencingHistory(long DeviceId, string alertTime, long alertId);//(long DeviceId);//,string alertTime

       // [OperationContract]
       // string AddDeviceHomeAutomation(string DeviceInfo);//(long DeviceId);//,string alertTime

       /// [OperationContract]
       // long CreateHomeAutomationAlert(AlertDetTest Trxn);//(long DeviceId);//,string alertTime

     //   [OperationContract]
      //  long CreateTestRequest(DeviceData strData);//(long DeviceId);//,string alertTime

        [OperationContract]
        IEnumerable<tblDeviceGeoTrackHistoryDTO> GetAssetsMoveHistory(long DeviceId, int IsLive, string StartDate, string EndDate, string authToken);//(long DeviceId);//,string alertTime

        [OperationContract]
        Stream UpdDeviceGeoHistory(GeotrackLiveDataDto content);//XElement content);//(gpsDataElement gpsDataElement);

        [OperationContract]
        IEnumerable<tblDeviceGeoTrackHistoryDTO> GetGeoDeviceStatus(Guid AuthToken);//(gpsDataElement gpsDataElement); trupti10Aug15 dashboard

        [OperationContract]
        IEnumerable<AssetTripDto> GetAssetsTripDetails(long DeviceId, string StartDate, string EndDate);//(long DeviceId);//,string alertTime trupti10Aug15 dashboard

    }

}
