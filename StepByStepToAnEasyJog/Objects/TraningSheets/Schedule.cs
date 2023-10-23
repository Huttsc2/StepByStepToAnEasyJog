using Newtonsoft.Json;

namespace StepByStepToAnEasyJog.Objects.TraningSheets
{
    public class Schedule
    {
        [JsonProperty("worksheet")]
        public int Worksheet { get; set; }

        [JsonProperty("column")]
        public int Column { get; set; }

        [JsonProperty("weeks")]
        public List<WeekSheet> Weeks { get; set; }
    }
}
