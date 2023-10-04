using Newtonsoft.Json;

namespace StepByStepToAnEasyJog.Objects
{
    public class TrainingProgramPhases
    {
        [JsonProperty("initiationPhaseWeeks")]
        public int InitiationPhaseWeeks { get; set; }

        [JsonProperty("developmentPhaseWeeks")]
        public int DevelopmentPhaseWeeks { get; set; }

        [JsonProperty("peakPhaseWeeks")]
        public int PeakPhaseWeeks { get; set; }

        [JsonProperty("taperPhaseWeeks")]
        public int TaperPhaseWeeks { get; set; }
    }
}
