using OfficeOpenXml;
using StepByStepToAnEasyJog.Objects;
using StepByStepToAnEasyJog.Utils;

namespace StepByStepToAnEasyJog.ProgramBuilder
{
    public class TrainingPhaseWeekCalculator
    {
        private FileInfo FileInfo = new FileInfo(PathFinder.GetPathToTable());
        private int WeeksToCompetition { get; set; }
        private TrainingProgramPhases TrainingProgramPhases { get; set; }
        public TrainingPhaseWeekCalculator(string weeks)
        {
            WeeksToCompetition = int.Parse(weeks);
            TrainingProgramPhases = new TrainingProgramPhases()
            {
                InitiationPhaseWeeks = 0,
                DevelopmentPhaseWeeks = 0,
                PeakPhaseWeeks = 0,
                TaperPhaseWeeks = 0
            };
            CalculatePhases();
        }

        private void CalculatePhases()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= WeeksToCompetition+1; row++)
                {
                    if (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Text))
                    {
                        TrainingProgramPhases.InitiationPhaseWeeks++;
                    }
                }

                for (int row = 2; row <= WeeksToCompetition+1; row++)
                {
                    if (!string.IsNullOrEmpty(worksheet.Cells[row, 2].Text))
                    {
                        TrainingProgramPhases.DevelopmentPhaseWeeks++;
                    }
                }

                for (int row = 2; row <= WeeksToCompetition+1; row++)
                {
                    if (!string.IsNullOrEmpty(worksheet.Cells[row, 3].Text))
                    {
                        TrainingProgramPhases.PeakPhaseWeeks++;
                    }
                }

                for (int row = 2; row <= WeeksToCompetition+1; row++)
                {
                    if (!string.IsNullOrEmpty(worksheet.Cells[row, 4].Text))
                    {
                        TrainingProgramPhases.TaperPhaseWeeks++;
                    }
                }
            }
        }

        public TrainingProgramPhases GetProgramPhases()
        {
            return TrainingProgramPhases;
        }
    }
}
