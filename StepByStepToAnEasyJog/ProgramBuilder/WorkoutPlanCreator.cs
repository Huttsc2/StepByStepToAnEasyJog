using OfficeOpenXml;
using StepByStepToAnEasyJog.Objects;
using StepByStepToAnEasyJog.Objects.ObjectsBuilders;
using StepByStepToAnEasyJog.Objects.TrainingRespons;
using StepByStepToAnEasyJog.Utils;
using StepByStepToAnEasyJog.Objects.TraningSheets;
using StepByStepToAnEasyJog.Utils.DataLoaders;

namespace StepByStepToAnEasyJog.ProgramBuilder
{
    public class WorkoutPlanCreator
    {
        private FileInfo FileInfo = new FileInfo(PathFinder.GetPathToTable());
        private string Distance { get; set; }
        private TrainingProgramPhases ProgramPhases { get; set; }
        private List<Week> Weeks { get; set; }
        private CompleteSchedule CompleteSchedule { get; set; }
        private int WeekNumber { get; set; }

        public WorkoutPlanCreator(string distans, TrainingProgramPhases trainingProgramPhases)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Weeks = new List<Week>();
            Distance = distans;
            ProgramPhases = trainingProgramPhases;
            WeekNumber = 1;
            CreateProgram();
            CreateInitWeeks();
            CreateDevWeeks();
            CreatePeakWeeks();
            CreateTaperWeeks();
        }

        private void CreateProgram()
        {
            switch (Distance)
            {
                case "800 м":
                    Create800mProgram();
                    break;
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

        private void Create800mProgram()
        {
            Schedule initSchedule = new JsonConfigReader().GetInit800();
            Schedule devSchedule = new JsonConfigReader().GetDev800();
            Schedule peakSchedule = new JsonConfigReader().GetPeak800();
            Schedule taperSchedul = new JsonConfigReader().GetTaper800();
            Schedule altTaperSchedul = new JsonConfigReader().GetAltTaper800();
            CompleteSchedule = new CompleteScheduleBuilder()
                .SetInitSchedule(initSchedule)
                .SetDevSchedule(devSchedule)
                .SetPeakSchedule(peakSchedule)
                .SetTaperSchedule(taperSchedul)
                .SetAltTaperSchedule(altTaperSchedul)
                .Build();
        }

        private void Create1500mOr3000mProgram()
        {
            Schedule initSchedule = new JsonConfigReader().GetInit15003000();
            Schedule devSchedule = new JsonConfigReader().GetDev15003000();
            Schedule peakSchedule = new JsonConfigReader().GetPeak15003000();
            Schedule taperSchedul = new JsonConfigReader().GetTaper15003000();
            Schedule altTaperSchedul = new JsonConfigReader().GetAltTaper15003000();
            CompleteSchedule = new CompleteScheduleBuilder()
                .SetInitSchedule(initSchedule)
                .SetDevSchedule(devSchedule)
                .SetPeakSchedule(peakSchedule)
                .SetTaperSchedule(taperSchedul)
                .SetAltTaperSchedule(altTaperSchedul)
                .Build();
        }

        private void Create5000mOr10kmProgram()
        {
            Schedule initSchedule = new JsonConfigReader().GetInit510();
            Schedule devSchedule = new JsonConfigReader().GetDev510();
            Schedule peakSchedule = new JsonConfigReader().GetPeak510();
            Schedule taperSchedul = new JsonConfigReader().GetTaper510();
            Schedule altTaperSchedul = new JsonConfigReader().GetAltTaper510();
            CompleteSchedule = new CompleteScheduleBuilder()
                .SetInitSchedule(initSchedule)
                .SetDevSchedule(devSchedule)
                .SetPeakSchedule(peakSchedule)
                .SetTaperSchedule(taperSchedul)
                .SetAltTaperSchedule(altTaperSchedul)
                .Build();
        }

        private void Create21kmOr42knProgram()
        {
            Schedule initSchedule = new JsonConfigReader().GetInit2142();
            Schedule devSchedule = new JsonConfigReader().GetDev2142();
            Schedule peakSchedule = new JsonConfigReader().GetPeak2142();
            Schedule taperSchedul = new JsonConfigReader().GetTaper2142();
            Schedule altTaperSchedul = new JsonConfigReader().GetAltTaper2142();
            CompleteSchedule = new CompleteScheduleBuilder()
                .SetInitSchedule(initSchedule)
                .SetDevSchedule(devSchedule)
                .SetPeakSchedule(peakSchedule)
                .SetTaperSchedule(taperSchedul)
                .SetAltTaperSchedule(altTaperSchedul)
                .Build();
        }

        private void CreateInitWeeks()
        {
            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[CompleteSchedule.InitSchedule.Worksheet];
                List<Week> weeks = new List<Week>();
                Week week;
                for (int i = 0; i < ProgramPhases.InitiationPhaseWeeks; i++)
                {
                    string additionalInfo = null;
                    string trainig = null;
                    bool isAdditionalInfo = CompleteSchedule.InitSchedule.Weeks[i].AdditionalInfo != null;
                    if (isAdditionalInfo)
                    {
                        foreach (int infoRow in CompleteSchedule.InitSchedule.Weeks[i].AdditionalInfo)
                        {
                            additionalInfo += worksheet.Cells[infoRow, CompleteSchedule.InitSchedule.Column].Text;
                            additionalInfo += "\n";
                        }
                    }

                    List<Day> days = new List<Day>();
                    for (int j = 0; j < CompleteSchedule.InitSchedule.Weeks[i].Days.Count; j++)
                    {
                        foreach (int trainingRow in CompleteSchedule.InitSchedule.Weeks[i].Days[j].TrainingDescription)
                        {
                            trainig += worksheet.Cells[trainingRow, CompleteSchedule.InitSchedule.Column].Text;
                            trainig += "\n";
                        }

                        days.Add(new DayBuilder()
                            .SetDayNumber(worksheet.Cells[CompleteSchedule.InitSchedule.Weeks[i].Days[j].DayNumber,
                            CompleteSchedule.InitSchedule.Column].Text)
                            .SetTrainingProgram(trainig)
                            .Build());

                        trainig = null;
                    }

                    week = new WeekBuilder()
                        .SetWeekNumber($"Неделя {WeekNumber}")
                        .SetAdditionalInfo(additionalInfo)
                        .SetDays(days)
                        .Build();

                    WeekNumber++;
                    Weeks.Add(week);
                }
            }   
        }

        private void CreateDevWeeks()
        {
            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[CompleteSchedule.DevSchedule.Worksheet];
                List<Week> weeks = new List<Week>();
                Week week;
                for (int i = 0; i < ProgramPhases.DevelopmentPhaseWeeks; i++)
                {
                    string additionalInfo = null;
                    string trainig = null;
                    bool isAdditionalInfo = CompleteSchedule.DevSchedule.Weeks[i].AdditionalInfo != null;
                    if (isAdditionalInfo)
                    {
                        foreach (int infoRow in CompleteSchedule.DevSchedule.Weeks[i].AdditionalInfo)
                        {
                            additionalInfo += worksheet.Cells[infoRow, CompleteSchedule.DevSchedule.Column].Text;
                            additionalInfo += "\n";
                        }
                    }

                    List<Day> days = new List<Day>();
                    for (int j = 0; j < CompleteSchedule.DevSchedule.Weeks[i].Days.Count; j++)
                    {
                        foreach (int trainingRow in CompleteSchedule.DevSchedule.Weeks[i].Days[j].TrainingDescription)
                        {
                            trainig += worksheet.Cells[trainingRow, CompleteSchedule.DevSchedule.Column].Text;
                            trainig += "\n";
                        }

                        days.Add(new DayBuilder()
                            .SetDayNumber(worksheet.Cells[CompleteSchedule.DevSchedule.Weeks[i].Days[j].DayNumber,
                            CompleteSchedule.DevSchedule.Column].Text)
                            .SetTrainingProgram(trainig)
                            .Build());

                        trainig = null;
                    }

                    week = new WeekBuilder()
                        .SetWeekNumber($"Неделя {WeekNumber}")
                        .SetAdditionalInfo(additionalInfo)
                        .SetDays(days)
                        .Build();

                    WeekNumber++;
                    Weeks.Add(week);
                }
            }
        }

        private void CreatePeakWeeks()
        {
            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[CompleteSchedule.PeakSchedule.Worksheet];
                List<Week> weeks = new List<Week>();
                Week week;
                for (int i = 0; i < ProgramPhases.PeakPhaseWeeks; i++)
                {
                    string additionalInfo = null;
                    string trainig = null;
                    bool isAdditionalInfo = CompleteSchedule.PeakSchedule.Weeks[i].AdditionalInfo != null;
                    if (isAdditionalInfo)
                    {
                        foreach (int infoRow in CompleteSchedule.PeakSchedule.Weeks[i].AdditionalInfo)
                        {
                            additionalInfo += worksheet.Cells[infoRow, CompleteSchedule.PeakSchedule.Column].Text;
                            additionalInfo += "\n";
                        }
                    }

                    List<Day> days = new List<Day>();
                    for (int j = 0; j < CompleteSchedule.PeakSchedule.Weeks[i].Days.Count; j++)
                    {
                        foreach (int trainingRow in CompleteSchedule.PeakSchedule.Weeks[i].Days[j].TrainingDescription)
                        {
                            trainig += worksheet.Cells[trainingRow, CompleteSchedule.PeakSchedule.Column].Text;
                            trainig += "\n";
                        }

                        days.Add(new DayBuilder()
                            .SetDayNumber(worksheet.Cells[CompleteSchedule.PeakSchedule.Weeks[i].Days[j].DayNumber,
                            CompleteSchedule.PeakSchedule.Column].Text)
                            .SetTrainingProgram(trainig)
                            .Build());

                        trainig = null;
                    }

                    week = new WeekBuilder()
                        .SetWeekNumber($"Неделя {WeekNumber}")
                        .SetAdditionalInfo(additionalInfo)
                        .SetDays(days)
                        .Build();

                    WeekNumber++;
                    Weeks.Add(week);
                }
            }
        }

        private void CreateTaperWeeks()
        {
            using (ExcelPackage package = new ExcelPackage(FileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[CompleteSchedule.TaperSchedule.Worksheet];
                List<Week> weeks = new List<Week>();
                Week week;
                for (int i = 0; i < ProgramPhases.TaperPhaseWeeks; i++)
                {
                    string additionalInfo = null;
                    string trainig = null;
                    bool isAdditionalInfo = CompleteSchedule.TaperSchedule.Weeks[i].AdditionalInfo != null;
                    if (isAdditionalInfo)
                    {
                        foreach (int infoRow in CompleteSchedule.TaperSchedule.Weeks[i].AdditionalInfo)
                        {
                            additionalInfo += worksheet.Cells[infoRow, CompleteSchedule.TaperSchedule.Column].Text;
                            additionalInfo += "\n";
                        }
                    }

                    List<Day> days = new List<Day>();
                    for (int j = 0; j < CompleteSchedule.TaperSchedule.Weeks[i].Days.Count; j++)
                    {
                        foreach (int trainingRow in CompleteSchedule.TaperSchedule.Weeks[i].Days[j].TrainingDescription)
                        {
                            trainig += worksheet.Cells[trainingRow, CompleteSchedule.TaperSchedule.Column].Text;
                            trainig += "\n";
                        }

                        days.Add(new DayBuilder()
                            .SetDayNumber(worksheet.Cells[CompleteSchedule.TaperSchedule.Weeks[i].Days[j].DayNumber,
                            CompleteSchedule.TaperSchedule.Column].Text)
                            .SetTrainingProgram(trainig)
                            .Build());

                        trainig = null;
                    }

                    week = new WeekBuilder()
                        .SetWeekNumber($"Неделя {WeekNumber}")
                        .SetAdditionalInfo(additionalInfo)
                        .SetDays(days)
                        .Build();

                    WeekNumber++;
                    Weeks.Add(week);
                }

                if (ProgramPhases.TaperPhaseWeeks < 6)
                {
                    Weeks.RemoveAt(Weeks.Count-1);

                    string trainig = null;
                    List<Day> days = new List<Day>();

                    for (int j = 0; j < CompleteSchedule.AltTaperSchedule.Weeks[ProgramPhases.TaperPhaseWeeks-1].Days.Count; j++)
                    {
                        foreach (int trainingRow in CompleteSchedule.AltTaperSchedule.Weeks[ProgramPhases.TaperPhaseWeeks-1]
                            .Days[j].TrainingDescription)
                        {
                            trainig += worksheet.Cells[trainingRow, CompleteSchedule.AltTaperSchedule.Column].Text;
                            trainig += "\n";
                        }

                        days.Add(new DayBuilder()
                            .SetDayNumber(worksheet.Cells[CompleteSchedule.AltTaperSchedule.Weeks
                            [ProgramPhases.TaperPhaseWeeks-1].Days[j].DayNumber,
                            CompleteSchedule.AltTaperSchedule.Column].Text)
                            .SetTrainingProgram(trainig)
                            .Build());

                        trainig = null;
                    }

                    week = new WeekBuilder()
                        .SetWeekNumber($"Неделя {--WeekNumber}")
                        .SetDays(days)
                        .Build();

                    Weeks.Add(week);
                }

            }
        }

        public List<Week> GetProgram()
        {
            return Weeks;
        } 
    }
}
