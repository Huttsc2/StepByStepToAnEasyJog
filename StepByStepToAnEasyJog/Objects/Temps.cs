using Newtonsoft.Json;

namespace StepByStepToAnEasyJog.Objects
{
    public class Temps
    {
        [JsonProperty("lTemp")]
        public string LTemp { get; set; }

        [JsonProperty("mTemp")]
        public string MTemp { get; set; }

        [JsonProperty("pTemp")]
        public string PTemp { get; set; }

        [JsonProperty("iTemp")]
        public string ITemp { get; set; }

        [JsonProperty("pvTemp200")]
        public string PvTemp200 { get; set; }

        [JsonProperty("pvTemp400")]
        public string PvTemp400 { get; set; }

        [JsonProperty("pvTemp600")]
        public string PvTemp600 { get; set; }

        [JsonProperty("pvTemp800")]
        public string PvTemp800 { get; set; }
    }
}
