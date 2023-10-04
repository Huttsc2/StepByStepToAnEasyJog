using System.Text.RegularExpressions;

namespace StepByStepToAnEasyJog.Utils
{
    public class PathFinder
    {
        public static string GetRootDirectory()
        {
            string dir = Directory.GetCurrentDirectory();
            Regex reg = new(".{0,}StepByStepToAnEasyJog");
            return reg.Match(dir).Captures.First().Value;
        }

        public static string GetPathToTable()
        {
            return $"{GetRootDirectory()}/Table/Run.xlsx";
        }
    }
}
