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
            TrainingAndDisclaimer trainingAndDisclaimer = new TrainingAndDisclaimer();
            string disclaimer = "<br><br><strong>Как рассчитана программа:</strong><p>" +
                "Программа тренировок рассчитана по книге выдающегося американского" +
                " тренера Джека Дэниэлса \"От 800 метров до марафона\".</p> <p>Все " +
                "методики, упражнения и тренировочный темп взяты из этой книги.</p>" +
                "<br><strong>Как пользоваться программой:</strong><p>Отдельно " +
                "выделены дни с обязательными тренировками. Рекомендуется не проводить " +
                "их подряд, а равномерно разнести на всю неделю.</p><p>Дополнительные " +
                "тренировки можно проводить в качестве восстановительных занятий между " +
                "основными днями.</p>";
            trainingAndDisclaimer.Weeks = weeks;
            trainingAndDisclaimer.Disclaimer = disclaimer;

            return Ok(trainingAndDisclaimer);
        }
    }
}
