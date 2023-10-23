using Newtonsoft.Json;

namespace StepByStepToAnEasyJog.Objects.TraningSheets
{
    public class WeekSheet
    {
        [JsonProperty("weekNumber")]
        public int WeekNumber { get; set; }

        [JsonProperty("additionalInfo")]
        public List<int>? AdditionalInfo { get; set; }

        [JsonProperty("days")]
        public List<DaySheet> Days { get; set; }
    }
}
