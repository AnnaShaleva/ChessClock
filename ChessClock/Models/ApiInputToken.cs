using Newtonsoft.Json;
using System;

namespace ChessClock.Models
{
    [Serializable]
    public class ApiInputToken
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }
    }
}
