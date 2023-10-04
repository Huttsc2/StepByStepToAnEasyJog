using OfficeOpenXml;
using StepByStepToAnEasyJog.Utils;

namespace StepByStepToAnEasyJog.ProgramBuilder
{
    public class VdotSearcher
    {
        private FileInfo FileInfo = new FileInfo(PathFinder.GetPathToTable());
        private string InputTime { get; set; }
        private string Distance { get; set; }
        private int Column { get; set; }
        private string Vdot { get; set; }

        public VdotSearcher(string inputTime, string distance)
        {
            if (distance != "Я не бегал ранее на скорость")
            {
                InputTime = inputTime;
                Distance = distance;
                SearchColumnByDistance();
                SearchVdotLevel();
            } 
            else
            {
                Vdot = "30";
            }
        }

        private void SearchColumnByDistance()
        {
            switch (Distance)
            {
                case "1500 м":
                    Column = 2;
                    break;
                case "3000 м":
                    Column = 3;
                    break;
                case "5000 м":
                    Column = 4;
                    break;
                case "10 км":
                    Column = 5;
                    break;
                case "21,1 км":
                    Column = 6;
                    break;
                case "42,2 км":
                    Column = 7;
                    break;
                default:
                    throw new Exception("not such distance");
            }
        }

        private void SearchVdotLevel()
        {
            TimeSpan time = TimeSpan.Parse(InputTime);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = 57;

                for (int row = 3; row <= rowCount; row++)
                {
                    string cellValue = worksheet.Cells[row, Column].Text;
                    if (TimeSpan.TryParse(cellValue, out TimeSpan currentTime))
                    {
                        if (currentTime < time)
                        {
                            Vdot = worksheet.Cells[row - 1, 1].Text;
                            break;
                        }
                        else if (row == rowCount)
                        {
                            Vdot = worksheet.Cells[row, 1].Text;
                        }
                    }
                }
            }
        }

        public string GetVdot()
        {
            return Vdot;
        }
    }
}
