using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using StepByStepToAnEasyJog.Objects.TrainingRespons;

namespace StepByStepToAnEasyJog.Objects.ObjectsBuilders
{
    public class WeekBuilder
    {
        private string weekNumber;
        private List<Day> days;
        private string additionalInfo;

        public WeekBuilder SetWeekNumber(string weekNumber)
        {
            this.weekNumber = weekNumber;
            return this;
        }

        public WeekBuilder SetDays(List<Day> days)
        {
            this.days = days;
            return this;
        }

        public WeekBuilder SetAdditionalInfo(string additionalInfo)
        {
            this.additionalInfo = additionalInfo;
            return this;
        }

        public Week Build()
        {
            return new Week
            {
                WeekNumber = weekNumber,
                Days = days,
                AdditionalInfo = additionalInfo
            };
        }
    }
}
