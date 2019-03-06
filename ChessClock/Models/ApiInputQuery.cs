using Newtonsoft.Json;
using System;

namespace ChessClock.Models
{
    [Serializable]
    public class ApiInputQuery
    {
        [JsonProperty("meta")]
        public ApiInputMeta Meta { get; set; }

        [JsonProperty("request")]
        public ApiInputRequest Request { get; set; }

        [JsonProperty("session")]
        public ApiInputSession Session { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
