using OfficeOpenXml;
using StepByStepToAnEasyJog.Objects;
using StepByStepToAnEasyJog.Utils;

namespace StepByStepToAnEasyJog.ProgramBuilder
{
    public class TempsSearcher
    {
        private FileInfo FileInfo = new FileInfo(PathFinder.GetPathToTable());
        private string Vdot { get; set; }
        private Temps Temps { get; set; }
        public TempsSearcher(string vdot)
        {
            Temps = new Temps();
            Vdot = vdot;
            SetTemps();
        }

        private void SetTemps()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[2];
                int rowCount = 58;

                for (int row = 2; row <= rowCount; row++)
                {
                    string cellValue = worksheet.Cells[row, 1].Text;
                    if (cellValue == Vdot)
                    {
                        Temps.LTemp = worksheet.Cells[row, 2].Text;
                        Temps.MTemp = worksheet.Cells[row, 3].Text;
                        Temps.PTemp = worksheet.Cells[row, 4].Text;
                        Temps.ITemp = worksheet.Cells[row, 5].Text;
                        Temps.PvTemp200 = worksheet.Cells[row, 6].Text;
                        Temps.PvTemp400 = worksheet.Cells[row, 7].Text;
                        Temps.PvTemp600 = worksheet.Cells[row, 8].Text;
                        Temps.PvTemp800 = worksheet.Cells[row, 9].Text;
                        break;
                    }
                }
            }
        }

        public Temps GetTemps()
        {
            return Temps;
        }
    }
}
