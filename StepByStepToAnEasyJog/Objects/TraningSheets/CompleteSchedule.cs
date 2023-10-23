using StepByStepToAnEasyJog.Objects.TraningSheets;

namespace StepByStepToAnEasyJog.Objects.TraningSheets
{
    public class CompleteSchedule
    {
        public Schedule InitSchedule { get; set; }
        public Schedule DevSchedule { get; set; }
        public Schedule PeakSchedule { get; set; }
        public Schedule TaperSchedule { get; set; }
        public Schedule AltTaperSchedule { get; set; }
    }
}
