using StepByStepToAnEasyJog.Objects.TraningSheets;

namespace StepByStepToAnEasyJog.Objects.ObjectsBuilders
{
    public class CompleteScheduleBuilder
    {
        private Schedule initSchedule;
        private Schedule devSchedule;
        private Schedule peakSchedule;
        private Schedule taperSchedule;
        private Schedule altTaperSchedule;

        public CompleteScheduleBuilder SetInitSchedule (Schedule initSchedule)
        {
            this.initSchedule = initSchedule;
            return this;
        }
        public CompleteScheduleBuilder SetDevSchedule(Schedule devSchedule)
        {
            this.devSchedule = devSchedule;
            return this;
        }
        public CompleteScheduleBuilder SetPeakSchedule(Schedule peakSchedule)
        {
            this.peakSchedule = peakSchedule;
            return this;
        }
        public CompleteScheduleBuilder SetTaperSchedule(Schedule taperSchedule)
        {
            this.taperSchedule = taperSchedule;
            return this;
        }
        public CompleteScheduleBuilder SetAltTaperSchedule(Schedule altTaperSchedule)
        {
            this.altTaperSchedule = altTaperSchedule;
            return this;
        }

        public CompleteSchedule Build()
        {
            return new CompleteSchedule
            {
                InitSchedule = initSchedule,
                DevSchedule = devSchedule,
                PeakSchedule = peakSchedule,
                TaperSchedule = taperSchedule,
                AltTaperSchedule = altTaperSchedule
            };
        }
    }
}
