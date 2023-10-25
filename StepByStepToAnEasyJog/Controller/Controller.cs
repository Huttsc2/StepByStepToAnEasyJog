using Microsoft.AspNetCore.Mvc;
using StepByStepToAnEasyJog.Objects;
using StepByStepToAnEasyJog.ProgramBuilder;
using System.Text.RegularExpressions;
using StepByStepToAnEasyJog.Objects.TrainingRespons;

namespace StepByStepToAnEasyJog.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RunPreparationData runData)
        {
            Regex regex = new Regex(@"(\d+) час(?:ов)? (\d+) минут (\d+) секунд");
            Match match = regex.Match(runData.Time);        
            if (match.Success)
            {
                string hours = match.Groups[1].Value;
                string minutes = match.Groups[2].Value;
                string seconds = match.Groups[3].Value;

                runData.Time = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            }

            string vdot = new VdotSearcher(runData.Time, runData.PreviousExperience).GetVdot();
            Temps temps = new TempsSearcher(vdot).GetTemps();
            TrainingProgramPhases trainingPhases = new TrainingPhaseWeekCalculator(runData.WeeksLeft).GetProgramPhases();
            List<Week> weeks = new WorkoutPlanCreator(runData.DistanceToPrepareFor, trainingPhases).GetProgram();
            weeks = new TempReplacer(temps, weeks).GetWeeks();

            return Ok(weeks);
        }
    }
}
