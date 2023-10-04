using OfficeOpenXml;
using StepByStepToAnEasyJog.Objects;
using StepByStepToAnEasyJog.Utils;
using System.Data.Common;

namespace StepByStepToAnEasyJog.ProgramBuilder
{
    public class WorkoutPlanCreator
    {
        private FileInfo FileInfo = new FileInfo(PathFinder.GetPathToTable());
        private Temps Temps {  get; set; }
        private string Distance { get; set; }
        private string Program { get; set; }
        private TrainingProgramPhases ProgramPhases { get; set; }
        public WorkoutPlanCreator(Temps temps, string distans, TrainingProgramPhases trainingProgramPhases)
        {
            Temps = temps;
            Distance = distans;
            ProgramPhases = trainingProgramPhases;
            CreateProgram();
            ReplaceTempoWithValue();
        }

        private void CreateProgram()
        {
            switch (Distance)
            {
                case "1500 м":
                case "3000 м":
                    Create1500mOr3000mProgram();
                    break;
                case "5000 м":
                case "10 км":
                    Create5000mOr10kmProgram();
                    break;
                case "21,1 км":
                case "42,2 км":
                    Create21kmOr42knProgram();
                    break;
                default:
                    throw new Exception("not such distance");
            }
        }

        private void Create1500mOr3000mProgram()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                int week = 1;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[4];

                for (int i = 0; i < ProgramPhases.InitiationPhaseWeeks; i++)
                {
                    Program += $"Неделя {week}\n\n";
                    Program += $"{worksheet.Cells[2, 1].Text}\n";
                    Program += $"{worksheet.Cells[3, 1].Text}\n\n";
                    week++;
                }

                for (int i = 0; i < ProgramPhases.DevelopmentPhaseWeeks; i++)
                {
                    Program += $"Вторая фаза\nНеделя {week}\n";
                    week++;
                }

                for (int i = 0; i < ProgramPhases.PeakPhaseWeeks; i++)
                {
                    Program += $"Третья фаза\nНеделя {week}\n";
                    week++;
                }

                for (int i = 0; i < ProgramPhases.TaperPhaseWeeks; i++)
                {
                    Program += $"Четвертая фаза\nНеделя {week}\n";
                    week++;
                }
            }

            
        }

        private void Create5000mOr10kmProgram()
        {

        }

        private void Create21kmOr42knProgram()
        {

        }

        private void ReplaceTempoWithValue()
        {

        }

        public string GetProgram()
        {
            return Program;
        } 
    }
}
