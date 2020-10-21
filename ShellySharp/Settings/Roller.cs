using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class Roller
    {
        [JsonProperty("maxtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Maxtime { get; set; }

        [JsonProperty("maxtime_open", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxtimeOpen { get; set; }

        [JsonProperty("maxtime_close", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxtimeClose { get; set; }

        [JsonProperty("default_state", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultState { get; set; }

        [JsonProperty("swap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Swap { get; set; }

        [JsonProperty("swap_inputs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SwapInputs { get; set; }

        [JsonProperty("input_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string InputMode { get; set; }

        [JsonProperty("button_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonType { get; set; }

        [JsonProperty("btn_reverse", NullValueHandling = NullValueHandling.Ignore)]
        public long? BtnReverse { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("power", NullValueHandling = NullValueHandling.Ignore)]
        public long? Power { get; set; }

        [JsonProperty("is_valid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsValid { get; set; }

        [JsonProperty("safety_switch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SafetySwitch { get; set; }

        [JsonProperty("roller_open_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RollerOpenUrl { get; set; }

        [JsonProperty("roller_close_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RollerCloseUrl { get; set; }

        [JsonProperty("roller_stop_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RollerStopUrl { get; set; }

        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Schedule { get; set; }

        [JsonProperty("schedule_rules", NullValueHandling = NullValueHandling.Ignore)]
        public object[] ScheduleRules { get; set; }

        [JsonProperty("obstacle_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string ObstacleMode { get; set; }

        [JsonProperty("obstacle_action", NullValueHandling = NullValueHandling.Ignore)]
        public string ObstacleAction { get; set; }

        [JsonProperty("obstacle_power", NullValueHandling = NullValueHandling.Ignore)]
        public long? ObstaclePower { get; set; }

        [JsonProperty("obstacle_delay", NullValueHandling = NullValueHandling.Ignore)]
        public long? ObstacleDelay { get; set; }

        [JsonProperty("safety_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string SafetyMode { get; set; }

        [JsonProperty("safety_action", NullValueHandling = NullValueHandling.Ignore)]
        public string SafetyAction { get; set; }

        [JsonProperty("safety_allowed_on_trigger", NullValueHandling = NullValueHandling.Ignore)]
        public string SafetyAllowedOnTrigger { get; set; }

        [JsonProperty("off_power", NullValueHandling = NullValueHandling.Ignore)]
        public long? OffPower { get; set; }

        [JsonProperty("positioning", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Positioning { get; set; }
    }
}
