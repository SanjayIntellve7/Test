using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using Fft.Cams.Core;
using Fft.Cams.Sdk;
using NLog;
using AMS.Broker.Contracts.DTO;
using AMS.Broker.TwTwFFTAdapterService.Helpers;
using System.Runtime.Serialization.Json;
using System.IO;

namespace AMS.Broker.TwTwFFTAdapterService.Services
{
    public class Cams3SdkUser : Cams3SdkBase
    {
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        public System.Timers.Timer _Timer = null;

        bool IsUpdating = false;
        //private Cams3SdkExampleForm form = null;
        private Dictionary<int, string> _zoneStatus = new Dictionary<int, string>();
        public Cams3SdkUser() //Cams3SdkExampleForm form
        {
            //this.form = form;
            if (_Timer == null)
            {
                _Timer = new System.Timers.Timer(3000);
                _Timer.Elapsed += _Timer_Elapsed;
            }
        }

        public void FFTTransactionServiceResetZoneAlarm(int zoneID, string status)//1
        {
            try
            {
                var json = JsonServicesHelper.GetJsonResponse("FFTTransactionService", "ResetZoneAlarm", "zoneID=" + zoneID, "status=" + status);
            }
            catch (Exception ex)
            {
            }
        }

        void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                IsUpdating = true;
                foreach (var _val in _zoneStatus)
                {
                    System.Threading.Tasks.Task.Run(() => FFTTransactionServiceResetZoneAlarm(_val.Key,_val.Value.ToString()));
                }
                IsUpdating = false;
                _zoneStatus.Clear();
            }
            catch (Exception ex)
            {
            }
            IsUpdating = false;
            _zoneStatus.Clear();
        }
        /// <summary>
        /// Called if the connection between the SDK and the server changes.
        /// </summary>
        /// <param name="connected"></param>
        public override void ConnectionStatus(bool connected)
        {
            //ConnectionStatusEx(connected, string.Empty);
        }

        /// <summary>
        /// Called if the connection between the SDK and the server changes.
        /// </summary>
        /// <param name="connected"></param>
        public override void ConnectionStatusEx(bool connected, string server)
        {
            if (connected)
            {
                //form.AddText("Connected to FFT CAMS 3 Server : " + server);
                GetZones();
                GetControllersStatus();
                GetOutstandingAlarms();
                GetIsolations();
                //GetZonesStatus(false);
                GetAutoAckStatus();
            }
            else
            {
                //form.AddText("!!! Disconnected from FFT CAMS 3 Server : " + server + " !!!");
            }
        }

        /// <summary>
        /// Called when the connection status between the server and FOSS controller changes.
        /// </summary>
        /// <param name="ctrlStatus"></param>
        public override void ControllerStatus(SdkCtrlStatus ctrlStatus)
        {
            //form.AddText("Controller <" + ctrlStatus.Name + ">" + (ctrlStatus.Connected ? " Connected" : " Not Connected"));
        }

        /// <summary>
        /// Called when a FFT CAMS 3 Client enters/leaves Edit Mode.
        /// </summary>
        /// <param name="editing"></param>
        public override void EditModeChanged(bool editing)
        {
            //form.AddText(editing ? "*** Edit Mode ***" : "--- Normal Mode ---");
        }

        /// <summary>
        /// Called when the redundancy state changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void RedundancyStateChanged(QuorumType quorumType, QuorumState quorumState, QuorumRole quorumRole, string connectedToPartner)
        {
            string msg = string.Format("Redundancy state: {0} Connected to Partner: {1}, Quorum Role: {2}, Quorum State: {3}, Quorum Type: {4}",
                quorumState == QuorumState.Synchronized ? "Redundant, " : "Non-redundant, ", connectedToPartner, quorumRole.ToString(), quorumState.ToString(), quorumType.ToString());

            //form.AddText(msg);
        }

        /// <summary>
        /// Called when the SDK is unable to proceed due to a licensing error. The following
        /// errors can occur:
        /// 1) The server licence is absent.
        /// 2) The server licence is an expired trial licence.
        /// 3) The SDK licence is absent.
        /// 4) The SDK licence is an expired trial licence.
        /// </summary>
        /// <param name="errorMessage"></param>
        public override void LicenceError(string errorMessage)
        {
            //form.AddText("!!! Licence Error !!!  -  " + errorMessage);
        }

        /// <summary>
        /// Displays information if the server or sdk is on a trial licence.
        /// </summary>
        /// <param name="serverTrial"></param>
        /// <param name="serverTrialExpiryDate"></param>
        /// <param name="clientTrial"></param>
        /// <param name="sdkTrialExpiryDate"></param>
        public override void TrialLicenceReminder(bool serverTrial, DateTime serverTrialExpiryDate, bool clientTrial, DateTime sdkTrialExpiryDate)
        {
            string line = string.Empty;
            string result = string.Empty;

            if (!serverTrial && !clientTrial)
                return;

            if (serverTrial)
                line = string.Format("Server is on trial licence. Server licence expires {0}. ", serverTrialExpiryDate.ToShortDateString());
            else
                line = "Server is on permanent licence. ";

            result += line;

            if (clientTrial)
                line = string.Format("SDK is on trial licence. SDK licence expires {0}. ", sdkTrialExpiryDate.ToShortDateString());
            else
                line = "SDK is on permanent licence.";

            result += line;
            //form.AddText(result);
        }

        /// <summary>
        /// Called when one of the following sensor alarm occurs:
        /// 1) Fibre Break
        /// 2) Optical Power Degraded
        /// 3) Laser Temperature Warning
        /// 4) Laser Shutdown
        /// 5) Laser Off
        /// 
        /// </summary>
        /// <param name="alarmId"></param>
        /// <param name="alarmTimeUtc"></param>
        /// <param name="alarmType"></param>
        /// <param name="acknowledged"></param>
        /// <param name="ctrl"></param>
        /// <param name="sensors"></param>
        /// <param name="isValidLocation"></param>
        /// <param name="location"></param>
        /// <param name="isOTDR"></param>
        public override void SensorAlarmEx2(long alarmId, DateTime alarmTimeUtc, SdkAlarmType alarmType, bool acknowledged, SdkCtrlData ctrl, List<SdkSensorData> sensors, bool isValidLocation, SdkLocationInfo location, bool isOTDR)
        {
            string locationStr = String.Empty;
            if (location != null)
                locationStr = location.Location.ToString();

            System.Threading.Tasks.Task.Run(() => FFTTransactionServiceCreateSensorAlert(alarmId, alarmTimeUtc, alarmType, acknowledged, ctrl, sensors, isValidLocation, location, isOTDR, "FFT Sensor Alert"));
           
            //form.AddText(alarmId.ToString() + " - [" + alarmType.Name + "] - Sensor Alarm Ex2 " + locationStr);
        }


        //2
        public void FFTTransactionServiceCreateSensorAlert(long alarmId, DateTime alarmTimeUtc, SdkAlarmType alarmType, bool acknowledged, SdkCtrlData ctrl, List<SdkSensorData> sensors, bool isValidLocation, SdkLocationInfo location, bool isOTDR,string strAlert)
        {
            try
            {
                SdkAlarmTypeDto _SdkAlarmTypeDto = new SdkAlarmTypeDto
                {
                    Category = alarmType.Category,
                    Id = alarmType.Id,
                    Name = alarmType.Name,
                    Severity = alarmType.Severity,
                    Type = alarmType.Type
                };

                SdkCtrlDataDto _SdkCtrlData = new SdkCtrlDataDto
                {
                    Connected = ctrl.Connected,
                    Description = ctrl.Description,
                    HostName = ctrl.HostName,
                    Id = ctrl.Id,
                    IpAddress = ctrl.IpAddress,
                    Locator = ctrl.Locator,
                    Name = ctrl.Name,
                    Port = ctrl.Port
                };

                List<SdkSensorDataDto> _sensors = new List<SdkSensorDataDto>();
                if(sensors!=null)
                {
                    try
                    {
                        foreach (var _sen in sensors)
                        {
                            List<CoordinateDto> _DrawingPoints = new List<CoordinateDto>();
                            foreach (var _cor in _sen.DrawingPoints)
                            {
                                CoordinateDto _CoordinateDto = new CoordinateDto
                                {
                                    Alt = _cor.Alt,
                                    IsEmpty = _cor.IsEmpty,
                                    Lat = _cor.Lat,
                                    Long = _cor.Long
                                };
                                _DrawingPoints.Add(_CoordinateDto);
                            }
                            List<SensorPointDto> _SensorPoints = new List<SensorPointDto>();
                            foreach (var _cor in _sen.SensorPoints)
                            {
                                CoordinateDto _CoordinateDto = new CoordinateDto
                                {
                                    Alt = _cor.coordinate.Alt,
                                    IsEmpty = _cor.coordinate.IsEmpty,
                                    Lat = _cor.coordinate.Lat,
                                    Long = _cor.coordinate.Long
                                };
                                SensorPointDto _SensorPointDto = new SensorPointDto
                                {
                                    cableDistance = _cor.cableDistance,
                                    calibrationPoint = _cor.calibrationPoint,
                                    calibrationPointName = _cor.calibrationPointName,
                                    coordinate = _CoordinateDto,
                                    id = _cor.id,
                                    perimeterDistance = _cor.perimeterDistance,
                                    seq = _cor.seq
                                };
                                _SensorPoints.Add(_SensorPointDto);
                            }
                            SdkSensorDataDto _SdkSensorDataDto = new SdkSensorDataDto
                            {
                                ControllerId = _sen.ControllerId,
                                DrawingPoints = _DrawingPoints,
                                Id = _sen.Id,
                                Name = _sen.Name,
                                Number = _sen.Number,
                                SensorPoints = _SensorPoints
                            };
                            _sensors.Add(_SdkSensorDataDto);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                SdkLocationInfoDto _location=null;
                if (location != null)
                {
                    CoordinateDto _CoordinateDto = new CoordinateDto
                    {
                        Alt = location.Location.Alt,
                        IsEmpty = location.Location.IsEmpty,
                        Lat = location.Location.Lat,
                        Long = location.Location.Long
                    };
                    _location = new SdkLocationInfoDto
                    {
                        CableDistance = location.CableDistance,
                        Location = _CoordinateDto,
                        LocationWeight = location.LocationWeight,
                        LocationWeightThreshold = location.LocationWeightThreshold,
                        PerimeterDistance = location.PerimeterDistance
                    };
                }
                //_SdkAlarmTypeDto, _SdkCtrlData ,_sensors ,    SdkLocationInfo location               
                FFTCreateAlarmParamDto _FFTCreateAlarmParamDto = new FFTCreateAlarmParamDto
                {
                    acknowledged=acknowledged,
                    alarmId=alarmId,
                    alarmTimeUtc=alarmTimeUtc.ToString(),
                    alarmType = _SdkAlarmTypeDto,
                    ctrl = _SdkCtrlData,
                    isOTDR=isOTDR,
                    isValidLocation=isValidLocation,
                    location = _location,
                    sensors = _sensors,
                    strAlertType = strAlert,
                    functiontype="SensorAlert"
                };

                //call json method here
                PushDataToFFTTxnService(_FFTCreateAlarmParamDto);
            }
            catch (Exception ex)
            { 
            }
        }

        /// <summary>
        /// Called when one of the following system alarm occurs:
        /// 1) FOSS Shutdown
        /// 2) SOP Degraded
        /// 3) FOSS Degraded
        /// 4) Locator Fault
        /// </summary>
        /// <param name="alarmId"></param>
        /// <param name="alarmTimeUtc"></param>
        /// <param name="alarmType"></param>
        /// <param name="acknowledged"></param>
        /// <param name="ctrlData"></param>
        public override void SystemAlarmEx(long alarmId, DateTime alarmTimeUtc, SdkAlarmType alarmType, bool acknowledged, SdkCtrlData ctrlData)
        {
            //form.AddText(alarmId.ToString() + " - [" + alarmType.Name + "] - System Alarm");
            System.Threading.Tasks.Task.Run(() => FFTTransactionServiceCreateAlert(alarmId, alarmTimeUtc,alarmType, acknowledged, ctrlData,"FFT SystemAlert"));            
        }

        public void FFTTransactionServiceCreateAlert(long alarmId, DateTime alarmTimeUtc, SdkAlarmType alarmType, bool acknowledged, SdkCtrlData ctrlData,string strAlertType)//3
        {
            try
            {
                SdkAlarmTypeDto _SdkAlarmTypeDto = null;
                if (alarmType != null)
                {
                    _SdkAlarmTypeDto = new SdkAlarmTypeDto
                    {
                        Category = alarmType.Category,
                        Id = alarmType.Id,
                        Name = alarmType.Name,
                        Severity = alarmType.Severity,
                        Type = alarmType.Type
                    };
                }
                SdkCtrlDataDto _SdkCtrlData = null;
                if (ctrlData != null)
                {
                    _SdkCtrlData = new SdkCtrlDataDto
                    {
                        Connected = ctrlData.Connected,
                        Description = ctrlData.Description,
                        HostName = ctrlData.HostName,
                        Id = ctrlData.Id,
                        IpAddress = ctrlData.IpAddress,
                        Locator = ctrlData.Locator,
                        Name = ctrlData.Name,
                        Port = ctrlData.Port
                    };
                }
                //FFTTransactionServiceCreateAlert(alarmId, alarmTimeUtc, acknowledged, false, false, ctrlData, null, null, null, null, 0, "FFT SystemAlert", alarmType));
               //  SdkAlarmType alarmType, SdkCtrlData ctrlData,string strAlertType

                FFTCreateAlarmParamDto _FFTCreateAlarmParamDto = new FFTCreateAlarmParamDto
                {
                    acknowledged = acknowledged,
                    alarmId = alarmId,
                    alarmTimeUtc = alarmTimeUtc.ToString(),
                    alarmType = _SdkAlarmTypeDto,
                    ctrl = _SdkCtrlData,
                    strAlertType = strAlertType,
                    functiontype = "SystemAlert"
                };

                //call json function
                PushDataToFFTTxnService(_FFTCreateAlarmParamDto);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// External Alarm
        /// </summary>
        /// <param name="alarmId"></param>
        /// <param name="alarmTimeUtc"></param>
        /// <param name="description"></param>
        public override void ExternalAlarm(long alarmId, DateTime alarmTimeUtc, string description)
        {
            //form.AddText(alarmId.ToString() + " - ExternalAlarm: " + description);
        }

        /// <summary>
        /// Called when an alarm is acknowledged. Note: An acknowledgement doesn't necessarily clear the alarm.
        /// For example, if there are two clients and both clients are set to "By All" acknowledgement mode, when
        /// the first client acknowledges the alarm AlarmAcknowledged(long alarmId) is invoked but the alarm is
        /// not cleared. When the second client acknowledges, AlarmAcknowledged(long alarmId) is invoked again
        /// and then the alarm is cleared.
        /// </summary>
        /// <param name="alarmId"></param>
        public override void AlarmAcknowledged(long alarmId)
        {
            //form.AddText(alarmId.ToString() + " - Alarm Acknowledged");
        }

        /// <summary>
        /// Called when the acknowledgement criteria (the alarm is acknowledge in accordance with every clients's acknowledgement mode)
        /// is met.
        /// </summary>
        /// <param name="alarmId"></param>
        public override void AlarmCleared(long alarmId)
        {
            //form.AddText(alarmId.ToString() + " - Alarm Cleared");
             System.Threading.Tasks.Task.Run(() => FFTTransactionServiceAlarmCleared(alarmId));//amit 07052018
        }
        public void FFTTransactionServiceAlarmCleared(long alarmId)//4
        {
            try
            {
                var json = JsonServicesHelper.GetJsonResponse("FFTTransactionService", "ClearFFTAlert","alarmId="+ alarmId);                          
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Called when the FFT CAMS 3 Server is in event mode. This aggregates multiple FOSS alarms into a single event if the alarms
        /// occur in close proximity on the sensor within a narrow timespan.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="eventTimeUtc"></param>
        /// <param name="acknowledged"></param>
        /// <param name="active"></param>
        /// <param name="dynamic"></param>
        /// <param name="ctrl"></param>
        /// <param name="sensor"></param>
        /// <param name="zone"></param>
        /// <param name="location"></param>
        /// <param name="classification"></param>
        /// <param name="classConfidenceIndex"></param>
        public override void ZoneEventEx(long eventId, DateTime eventTimeUtc, bool acknowledged, bool active, bool dynamic, SdkCtrlData ctrl, SdkSensorData sensor, SdkZoneData zone, SdkLocationInfo location, string classification, int classConfidenceIndex)
        {
            System.Threading.Tasks.Task.Run(() => FFTTransactionServiceCreateAlertZoneEx(eventId, eventTimeUtc, acknowledged, active, dynamic, ctrl, sensor, zone, location, classification, classConfidenceIndex, "FFT Zone Alert"));
            
            //form.AddText(eventId.ToString() + " - <" + zone.Name + "> - Zone Event Ex at: " + location.Location.ToString(LatLongFormat.DecimalDegrees) + " Perimeter Distance: " + location.PerimeterDistance + "m. Cable Distance: " + location.CableDistance + "m." + " class: \"" + classification + "\", Background Noise Level: " + classConfidenceIndex);
        }
        //5
        public void FFTTransactionServiceCreateAlertZoneEx(long eventId, DateTime eventTimeUtc, bool acknowledged, bool active, bool dynamic, SdkCtrlData ctrl, SdkSensorData sensor, SdkZoneData zone, SdkLocationInfo location, string classification, int classConfidenceIndex, string strAlertType)
        {
            try
            {
                SdkCtrlDataDto _SdkCtrlData = null;
                if (ctrl != null)
                {
                    _SdkCtrlData = new SdkCtrlDataDto
                    {
                        Connected = ctrl.Connected,
                        Description = ctrl.Description,
                        HostName = ctrl.HostName,
                        Id = ctrl.Id,
                        IpAddress = ctrl.IpAddress,
                        Locator = ctrl.Locator,
                        Name = ctrl.Name,
                        Port = ctrl.Port
                    };
                }

                List<CoordinateDto> _DrawingPoints = new List<CoordinateDto>();
                foreach (var _cor in sensor.DrawingPoints)
                {
                    CoordinateDto _CoordinateDto = new CoordinateDto
                    {
                        Alt = _cor.Alt,
                        IsEmpty = _cor.IsEmpty,
                        Lat = _cor.Lat,
                        Long = _cor.Long
                    };
                    _DrawingPoints.Add(_CoordinateDto);
                }
                List<SensorPointDto> _SensorPoints = new List<SensorPointDto>();
                foreach (var _cor in sensor.SensorPoints)
                {
                    CoordinateDto _CoordinateDto = new CoordinateDto
                    {
                        Alt = _cor.coordinate.Alt,
                        IsEmpty = _cor.coordinate.IsEmpty,
                        Lat = _cor.coordinate.Lat,
                        Long = _cor.coordinate.Long
                    };
                    SensorPointDto _SensorPointDto = new SensorPointDto
                    {
                        cableDistance = _cor.cableDistance,
                        calibrationPoint = _cor.calibrationPoint,
                        calibrationPointName = _cor.calibrationPointName,
                        coordinate = _CoordinateDto,
                        id = _cor.id,
                        perimeterDistance = _cor.perimeterDistance,
                        seq = _cor.seq
                    };
                    _SensorPoints.Add(_SensorPointDto);
                }
                SdkSensorDataDto _SdkSensorDataDto = new SdkSensorDataDto
                {
                    ControllerId = sensor.ControllerId,
                    DrawingPoints = _DrawingPoints,
                    Id = sensor.Id,
                    Name = sensor.Name,
                    Number = sensor.Number,
                    SensorPoints = _SensorPoints
                };

                 List<SensorSectionDto> _SensorSections = new List<SensorSectionDto>();

                  foreach (var __SensorSections in zone.SensorSections)
                  {
                      List<CoordinateDto> Points = new List<CoordinateDto>();
                      foreach (var _cord in __SensorSections.Points)
                      {
                          CoordinateDto _CoordinateDto = new CoordinateDto
                          {
                              Alt = _cord.Alt,
                              IsEmpty = _cord.IsEmpty,
                              Lat = _cord.Lat,
                              Long = _cord.Long
                          };

                          Points.Add(_CoordinateDto);
                      }
                      SensorSectionDto _SensorSectionDto = new SensorSectionDto
                      {
                          CableEnd = __SensorSections.CableEnd,
                          CableStart = __SensorSections.CableStart,
                          Opposite = __SensorSections.Opposite,
                          PerimeterEnd = __SensorSections.PerimeterEnd,
                          PerimeterStart = __SensorSections.PerimeterStart,
                          Points = Points,
                          Reversed = __SensorSections.Reversed,
                          SectionId = __SensorSections.SectionId,
                          SensorEndIdx = __SensorSections.SensorEndIdx,
                          SensorId = __SensorSections.SensorId,
                          SensorStartIdx = __SensorSections.SensorStartIdx,
                          ServerId = __SensorSections.ServerId
                      };

                      _SensorSections.Add(_SensorSectionDto);
                  }
                  SdkZoneDataDTO _SdkZoneDataDTO = new SdkZoneDataDTO
                  {
                      Isolated = zone.Isolated,
                      Description = zone.Description,
                      Id = zone.Id,
                      Name = zone.Name,
                      SensorSections = _SensorSections
                  };

                  CoordinateDto _CoordinateDtoinfo = new CoordinateDto
                  {
                      Alt = location.Location.Alt,
                      IsEmpty = location.Location.IsEmpty,
                      Lat = location.Location.Lat,
                      Long = location.Location.Long
                  };
                  SdkLocationInfoDto _location = new SdkLocationInfoDto
                  {
                      CableDistance = location.CableDistance,
                      Location = _CoordinateDtoinfo,
                      LocationWeight = location.LocationWeight,
                      LocationWeightThreshold = location.LocationWeightThreshold,
                      PerimeterDistance = location.PerimeterDistance
                  };

                //SdkCtrlData _SdkCtrlData, SdkSensorData _SdkSensorDataDto, SdkZoneData _SdkZoneDataDTO, SdkLocationInfo _location
                  //    string classification, int classConfidenceIndex, string strAlertType
                  FFTCreateAlarmParamDto _FFTCreateAlarmParamDto = new FFTCreateAlarmParamDto
                  {
                      acknowledged = acknowledged,
                      alarmId = eventId,
                      alarmTimeUtc = eventTimeUtc.ToString(),  
                      ctrl = _SdkCtrlData,  
                      location = _location,
                      sensor = _SdkSensorDataDto,
                      zone=_SdkZoneDataDTO,
                      classification=classification,
                      strAlertType = strAlertType,
                      functiontype = "ZoneAlert"
                  };
                //call json
                  PushDataToFFTTxnService(_FFTCreateAlarmParamDto);
            }
            catch (Exception ex)
            {
            }
        }

        public static string SerializeObject(FFTCreateAlarmParamDto graph)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(FFTCreateAlarmParamDto));
                string jsonCode;

                using (var ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, graph);
                    jsonCode = Encoding.Default.GetString(ms.ToArray());
                }

                return jsonCode;
            }
            catch (Exception ex)
            {
                _logger.Info("StreamInsightAlertService SerializeObject() Exception:" + ex.Message);
                string Message = "StreamInsightAlertService SerializeObject() Exception 1" + ex.Message;
                //InsertBrokerOperationLog.AddProcessLog(Message);
                //InsertTransactionLog.InsertLog(Message);//jatin
            }
            finally
            {
                //ClearMemoryStatic();
            }
            return null;
        }

        public void PushDataToFFTTxnService(FFTCreateAlarmParamDto _FFTCreateAlarmParamDto)
        {
            try
            {              
                string strData = SerializeObject(_FFTCreateAlarmParamDto);
                var json = JsonServicesHelper.GetJsonResponsePost("FFTTransactionService", "ConsumeFFTAlert", _FFTCreateAlarmParamDto);
            }
            catch(Exception ex)
            {
            }
        }
        /// <summary>
        /// As more FOSS alarms are received for an event, the event details (such as location) are updated.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="lastUpdateUtc"></param>
        /// <param name="ctrl"></param>
        /// <param name="sensor"></param>
        /// <param name="location"></param>
        public override void ZoneEventUpdate(long eventId, DateTime lastUpdateUtc, SdkCtrlData ctrl, SdkSensorData sensor, SdkLocationInfo location)
        {
            //form.AddText(eventId.ToString() + " - Zone Event Update, Time: " + lastUpdateUtc.ToLocalTime().ToString() + ", Location: " + location.Location.ToString(LatLongFormat.DecimalDegrees));
        }

        /// <summary>
        /// Called whenever a client acknowledges the event.
        /// </summary>
        /// <param name="eventId"></param>
        public override void ZoneEventAcknowledged(long eventId)
        {
            //form.AddText(eventId.ToString() + " - Zone Event Acknowledged");

            _logger.Info(eventId.ToString() + " - Zone Event Acknowledged");
        }

        /// <summary>
        /// Called when an event is no longer active. FFT CAMS 3 Clients can set the duration of an event.
        /// </summary>
        /// <param name="eventId"></param>
        public override void ZoneEventDeactivated(long eventId)
        {
            //form.AddText(eventId.ToString() + " - Zone Event Deactivated");
            _logger.Info(eventId.ToString() + " - Zone Event Deactivated");
        }

        /// <summary>
        /// Called when the acknowledgement criteria for the event has been met. For example, if every client is set to "By All" acknowledgement mode,
        /// then the event won't be cleared until every client acknowledges the event.
        /// </summary>
        /// <param name="eventId"></param>
        public override void ZoneEventCleared(long eventId)
        {
            //form.AddText(eventId.ToString() + " - Zone Event Cleared");
            _logger.Info(eventId.ToString() + " - Zone Event Cleared");
        }

        /// <summary>
        /// Called when Zone-Isolation status changes
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="zoneName"></param>
        /// <param name="isolated"></param>
        public override void ZoneIsolated(int zoneId, string zoneName, bool isolated)
        {
            if (isolated)
            {
                //form.AddText(zoneId.ToString() + " - <" + zoneName + "> - Zone Isolated");
            }
            else
            {
                //form.AddText(zoneId.ToString() + " - <" + zoneName + "> - Zone-Isolation Removed");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zoneId"></param>
        /// <param name="zoneName"></param>
        /// <param name="isolated"></param>
        /// <param name="config"></param>
        public override void ZoneIsolatedEx(int zoneId, string zoneName, bool isolated, string config)
        {
            List<string> classifications = config.GetIsolationCommsNames();

            if (isolated)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string classification in classifications)
                    sb.Append(classification + ",");

                //form.AddText("ZoneIsolatedEx: " + zoneId.ToString() + " - <" + zoneName + "> - Zone Isolated. Classifications: " + sb.ToString());
            }
            else
            {
                //form.AddText("ZoneIsolatedEx: " + zoneId.ToString() + " - <" + zoneName + "> - Zone-Isolation Removed");
            }
        }


        public override void OnZoneStatusUpdate(SdkZoneData zone, SdkZoneStatus status)
        {
            //form.AddText(zone.Id.ToString() + " - <" + zone.Name + "> - Status update - " + status.ToString());
            if (IsUpdating == false)
            {
                try
                {
                    if (_zoneStatus.ContainsKey(zone.Id))
                    {
                        _zoneStatus[zone.Id] = status.ToString();
                    }
                    else
                    {
                        _zoneStatus.Add(zone.Id, status.ToString());
                    }
                    _logger.Info(zone.Id.ToString() + " - <" + zone.Name + "> - Status update - " + status.ToString());
                    if (_Timer.Enabled)
                        _Timer.Stop();
                    _Timer.Start();
                }
                catch (Exception ex)
                { 
                }
            }
           //System.Threading.Tasks.Task.Run(() => FFTTransactionService.ResetZoneAlarm(zone.Id, status.ToString()));
        }

        public override void AutoAckChanged(bool autoAckOn, long delay, bool ackSensorAlarms, bool ackSystemAlarms)
        {
            if (autoAckOn)
            {
                //form.AddText("Auto Acknowledgement state changed to ON.");
            }
            else
            {
                //form.AddText("Auto Acknowledgement state changed to OFF.");
            }
        }
        
    }

}
