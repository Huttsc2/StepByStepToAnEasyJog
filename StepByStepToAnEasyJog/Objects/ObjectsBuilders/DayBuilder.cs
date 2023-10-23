using StepByStepToAnEasyJog.Objects.TrainingRespons;

namespace StepByStepToAnEasyJog.Objects.ObjectsBuilders
{
    public class DayBuilder
    {
        private string dayNumber;
        private string trainingProgram;

        public DayBuilder SetDayNumber(string dayNumber)
        {
            this.dayNumber = dayNumber;
            return this;
        }

        public DayBuilder SetTrainingProgram(string trainingProgram)
        {
            this.trainingProgram = trainingProgram;
            return this;
        }

        public Day Build()
        {
            return new Day
            {
                DayNumber = dayNumber,
                TrainingProgram = trainingProgram
            };
        }
    }
}
