using StepByStepToAnEasyJog.Objects;
using StepByStepToAnEasyJog.Objects.TrainingRespons;

namespace StepByStepToAnEasyJog.ProgramBuilder
{
    public class TempReplacer
    {
        private Temps Temps { get; set; }
        private List<Week> Weeks { get; set; }

        public TempReplacer(Temps temps, List<Week> weeks)
        {
            Temps = temps;
            Weeks = weeks;
            FormatTempo();
        }

        private string ReplaceTempoPlaceholders(string input)
        {
            Dictionary<string, string> replacements = new Dictionary<string, string>
            {
                { "[L]", Temps.LTemp },
                { "[M]", Temps.MTemp },
                { "[P]", Temps.PTemp },
                { "[I]", Temps.ITemp },
                { "[Pov200]", Temps.PvTemp200 },
                { "[Pov400]", Temps.PvTemp400 },
                { "[Pov600]", Temps.PvTemp600 },
                { "[Pov800]", Temps.PvTemp800 },
            };

            foreach (KeyValuePair<string, string> pair in replacements)
            {
                input = input.Replace(pair.Key, pair.Value);
            }

            return input;
        }

        private void FormatTempo()
        {
            foreach (Week week in Weeks)
            {
                foreach (Day day in week.Days)
                {
                    day.TrainingProgram = ReplaceTempoPlaceholders(day.TrainingProgram);
                }
            }
        }

        public List<Week> GetWeeks()
        { 
            return Weeks; 
        }
    }
}
