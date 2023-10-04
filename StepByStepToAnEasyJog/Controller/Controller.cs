using Microsoft.AspNetCore.Mvc;
using StepByStepToAnEasyJog.Objects;
using StepByStepToAnEasyJog.ProgramBuilder;
using System.Text.RegularExpressions;

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

            Console.WriteLine($"{runData.DistanceToPrepareFor} {runData.PreviousExperience} {runData.WeeksLeft} {runData.Time}");

            string vdot = new VdotSearcher(runData.Time, runData.PreviousExperience).GetVdot();
            Temps temps = new TempsSearcher(vdot).GetTemps();
            TrainingProgramPhases trainingPhases = new TrainingPhaseWeekCalculator(runData.WeeksLeft).GetProgramPhases();
            string program = new WorkoutPlanCreator(temps, runData.DistanceToPrepareFor, trainingPhases).GetProgram();

            Console.WriteLine($"vdot {vdot}");
            Console.WriteLine($"L-temp {temps.LTemp}");
            Console.WriteLine($"M-temp {temps.MTemp}");
            Console.WriteLine($"P-temp {temps.PTemp}");
            Console.WriteLine($"I-temp {temps.ITemp}");
            Console.WriteLine($"Pv200-temp {temps.PvTemp200}");
            Console.WriteLine($"Pv400-temp {temps.PvTemp400}");
            Console.WriteLine($"init {trainingPhases.InitiationPhaseWeeks}");
            Console.WriteLine($"dev {trainingPhases.DevelopmentPhaseWeeks}");
            Console.WriteLine($"peak {trainingPhases.PeakPhaseWeeks}");
            Console.WriteLine($"taper {trainingPhases.TaperPhaseWeeks}");
            Console.WriteLine(program);

            return Ok();
        }
    }
}
