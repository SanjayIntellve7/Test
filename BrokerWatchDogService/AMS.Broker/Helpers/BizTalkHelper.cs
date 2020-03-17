using System;
using AMS.Broker.Contracts.DTO;
using AutoMapper;
using AMS.Broker.WatchDogService.AlertProcessingServiceReference;
using NLog;

namespace AMS.Broker.WatchDogService.Helpers
{

    public interface IBizTalkHelper
    {
        void ProcessAlert(Contracts.DTO.Alert dto);
        void ProcessIncidentReport(IncidentReport dto);
    }

    public class BizTalkHelper : IBizTalkHelper
    {

        public BizTalkHelper()
        {
            _alertClient = new AlertProcessingServiceClient();
            _alertClient.ProcessCompleted += client_ProcessCompleted;
        }


        public void ProcessAlert(Contracts.DTO.Alert dto)
        {
            try
            {
                var alert = Mapper.Map<AlertProcessingServiceReference.Alert>(dto);
                alert.WorkflowStatus = "Input";

                _alertClient.ProcessAsync(new ProcessRequest(alert), alert);
            }
            catch (Exception e)
            {
                _logger.LogException(LogLevel.Error, "Failed to transmit Alert to BizTalk", e);
            }
        }


        public void ProcessIncidentReport(IncidentReport dto)
        {
            try
            {


            }
            catch (Exception e)
            {
                _logger.LogException(LogLevel.Error, "Failed to transmit Incident Report to BizTalk", e);
            }
        }


        private void client_ProcessCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                _logger.Info("Sucessfuly connected to BizTalk.");
            else
                _logger.Error(e.Error.Message);
        }

        private void CreateMaps()
        {
            Mapper.CreateMap<Resource, AlertInfoResource>();
            Mapper.CreateMap<Parameter, AlertInfoParameter>();
            Mapper.CreateMap<Area, AlertInfoArea>();
            Mapper.CreateMap<Info, AlertInfo>();
            Mapper.CreateMap<Contracts.DTO.Alert, AlertProcessingServiceReference.Alert>();

        }


        private AlertProcessingServiceClient _alertClient;
        private static Logger _logger = LogManager.GetCurrentClassLogger();


    }
}
