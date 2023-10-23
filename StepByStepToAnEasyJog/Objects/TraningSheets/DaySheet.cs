using Newtonsoft.Json;

namespace StepByStepToAnEasyJog.Objects.TraningSheets
{
    public class DaySheet
    {
        [JsonProperty("dayNumber")]
        public int DayNumber { get; set; }

        [JsonProperty("trainingDescription")]
        public List<int> TrainingDescription { get; set; }
    }
}
