using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMS.Broker.IntegrationService
{
    internal sealed class SecurityPriviliges
    {
        public const string AccessAlert = "2020" + "alert-access-all";
        public const string SubmitAlert = "2020" + "alert-submit";

        public const string UpdateAlert = "2020" + "alert-update";

        public const string GetStation = "2020" + "get-station-";

        public const string AccessDeviceById = "2020" + "device-access-by-id-";
        public const string AccessDeviceByNvr = "2020" + "device-access-by-nvr-";
        public const string AccessDeviceAll = "2020" + "device-access-all";
        public const string AccessDeviceTypes = "2020" + "device-get-types";

        public const string StationAdmin = "2020" + "station-admin";
        public const string SentDeviceToStation = "2020" + "station-sent-device";
        public const string ActivateStation = "2020" + "station-activate";
        public const string UpdateStation = "2020" + "station-update";
        public const string RegisterStation = "2020" + "station-register";

        public const string StationsGetListById = "2020" + "station-get-list-by-";
        public const string StationsGetAll = "2020" + "station-get-all";

        public const string GetAllGroups = "2020" + "groups-get-all";
        public const string GetGroupById = "2020" + "group-get-by-id-";
        public const string CreateGroup = "2020" + "group-create";
        public const string UpdateGroup = "2020" + "group-update";

        public const string ManageIncident = "2020" + "manage-incident";
        public const string GetIncident = "2020" + "get-incident";

        public const string GetZonesById = "2020" + "zones-access-by-id-";
        public const string GetZonesAll = "2020" + "zones-access-all";

        public const string UserLocationAll = "2020" + "user-location-access-all";

        public const string ADGroupCreate = "2020" + "ad-groups-create";
        public const string ADGroupRemove = "2020" + "ad-groups-remove";
        public const string ADGroupGetUsers = "2020" + "ad-groups-get-users";

        public const string GetAlertsKpi = "2020" + "get-alerts-kpi";

        public const string AddNvr = "2020" + "add-nvr";
        public const string DeleteNvr = "2020" + "delete-nvr";        
        public const string GetNvrById = "2020" + "get-nvr-by-id-";
        public const string UpdateNvr = "2020" + "update-nvr";

        public const string UpdateZone = "2020" + "update-zone";
        public const string AddZone = "2020" + "add-zone";
        public const string DeleteZone = "2020" + "delete-zone";
        public const string AddZoneLocation = "2020" + "add-zone-location";
        public const string UpdateZoneLocation = "2020" + "update-zone-location";
        public const string DeleteZoneLocation = "2020" + "delete-zone-location";
        
        
    }
}
