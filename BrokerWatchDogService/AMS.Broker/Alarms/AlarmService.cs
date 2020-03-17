using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AMS.Broker
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AlarmService : IAlarmService
    {
        public AlarmService(ILogger logger)
        {
            _logger = logger;
        }

        public event Action PingReceived;
        public event Action DisconnectReceived;

        public bool NotifyAlarm(string systemId, string alarmId, int alarmType, int severity, string message, double longitude, double latitude)
        {

            _logger.Log("AlarmService.NotifyAlarm");

            List<string> notifyList = new List<string>();

            foreach (var controllerId in _notificationList.Keys)
            {
                var alarms = _notificationList[controllerId];
                if (alarms.Contains(alarmId))
                {
                    notifyList.Add(controllerId);
                }
            }

            foreach (var controller in notifyList)
            {
                _clients[controller].ReceiveAlarm(alarmId, alarmType, severity, message, longitude, latitude);
            }

            if (notifyList.Count > 0)
            {
                return true;
            }


            return false;
        }

        public void Ping(string systemId, string controllerId)
        {
            var client = OperationContext.Current.GetCallbackChannel<IAlarmClient>();

            if (!_clients.Keys.Contains(controllerId))
            {
                // throw -> unknown controller or not logged in / registered
            }

            _logger.Log("Ping received at " + DateTime.Now.ToLongTimeString() + " from " + controllerId);

            //if (PingReceived != null) PingReceived();

            client.Pong();
        }

        public string Register(string systemId, string username, string password, string controllerId, string[] alarmIds)
        {
            _logger.Log("AlarmService.Register");

            // TODO: validate username / password

            // add / append to notify list
            var alarmSet =  new List<string>(alarmIds);

            if (_notificationList.Keys.Contains(controllerId))
            {
                List<string> existingAlarms = _notificationList[controllerId];
                alarmSet = alarmIds.Union(existingAlarms).ToList();
                _notificationList.Remove(controllerId);
            }

            _notificationList.Add(controllerId, new List<string>(alarmSet));
         
            // generate session guid
            var session = Guid.NewGuid();

            //_sessionList.Add(systemId, DateTime.Now);

            return session.ToString();
        }

        public bool Deregister(string systemId, string username, string password, string controllerId, string[] alarmIds)
        {

            _logger.Log("AlarmService.Deregister");

            if (_notificationList.Keys.Contains(controllerId))
            {
                List<string> existingAlarms = _notificationList[controllerId];

                var alarmSet = from alarms in existingAlarms
                               where !alarmIds.Contains(alarms)
                               select alarms;

                _notificationList.Remove(controllerId);

                if (alarmSet.Count() > 0)
                {
                    _notificationList.Add(controllerId, new List<string>(alarmSet));
                }
            }

            return true;
        }

        public bool ResetAlarm(string systemId, string token, string controllerId, string alarmId)
        {
            _logger.Log("AlarmService.ResetAlarm");
            return true;
        }

        public void Disconnect(string systemId, string token, string controllerId)
        {

            _logger.Log("Disconnect received at " + DateTime.Now.ToLongTimeString());


            var client = OperationContext.Current.GetCallbackChannel<IAlarmClient>();

            // remove from list of clients
            if (_clients.Keys.Contains(controllerId))
            {
                _clients.Remove(controllerId);
            }

            // remove all entries from notification list
            if (_notificationList.Keys.Contains(controllerId))
            {
                _notificationList.Remove(controllerId);
            }

            // end session ...

           
            if (DisconnectReceived != null) DisconnectReceived();

        }

        private ILogger _logger;
        private static Dictionary<string, IAlarmClient> _clients = new Dictionary<string, IAlarmClient>();
        private static Dictionary<string, DateTime> _sessionList = new Dictionary<string, DateTime>();

        // controller / alarms
        private static Dictionary<string, List<string>> _notificationList = new Dictionary<string, List<string>>();
    }
}
