using Newtonsoft.Json;

namespace StepByStepToAnEasyJog.Objects
{
    public class RunPreparationData
    {
        [JsonProperty("distanceToPrepareFor")]
        public string DistanceToPrepareFor { get; set; }

        [JsonProperty("weeksLeft")]
        public string WeeksLeft { get; set; }

        [JsonProperty("previousExperience")]
        public string PreviousExperience { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
