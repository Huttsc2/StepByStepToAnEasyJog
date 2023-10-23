using Newtonsoft.Json;
using StepByStepToAnEasyJog.Objects.TraningSheets;

namespace StepByStepToAnEasyJog.Utils.DataLoaders
{
    public class JsonConfigReader
    {
        private string PathToConfigs = $"{PathFinder.GetRootDirectory()}/WorkoutConfigs/";

        private string ReadFileContent(string fileName)
        {
            using StreamReader r = new($"{PathToConfigs}{fileName}");
            return r.ReadToEnd();
        }

        public Schedule GetInit800() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("800m/init800.json"));
        public Schedule GetDev800() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("800m/dev800.json"));
        public Schedule GetPeak800() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("800m/peak800.json"));
        public Schedule GetTaper800() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("800m/taper800.json"));
        public Schedule GetAltTaper800() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("800m/altTaper800.json"));

        public Schedule GetInit15003000() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("1500m-3000m/init1500-3000.json"));
        public Schedule GetDev15003000() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("1500m-3000m/dev1500-3000.json"));
        public Schedule GetPeak15003000() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("1500m-3000m/peak1500-3000.json"));
        public Schedule GetTaper15003000() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("1500m-3000m/taper1500-3000.json"));
        public Schedule GetAltTaper15003000() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("1500m-3000m/altTaper1500-3000.json"));

        public Schedule GetInit510() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("5km-10km/init5-10.json"));
        public Schedule GetDev510() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("5km-10km/dev5-10.json"));
        public Schedule GetPeak510() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("5km-10km/peak5-10.json"));
        public Schedule GetTaper510() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("5km-10km/taper5-10.json"));
        public Schedule GetAltTaper510() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("5km-10km/altTaper5-10.json"));

        public Schedule GetInit2142() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("21km-42km/init21-42.json"));
        public Schedule GetDev2142() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("21km-42km/dev21-42.json"));
        public Schedule GetPeak2142() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("21km-42km/peak21-42.json"));
        public Schedule GetTaper2142() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("21km-42km/taper21-42.json"));
        public Schedule GetAltTaper2142() => JsonConvert.DeserializeObject<Schedule>(ReadFileContent("21km-42km/altTaper21-42.json"));

    }
}
