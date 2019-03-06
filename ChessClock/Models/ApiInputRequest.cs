using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ChessClock.Kernel.Enums;
using System;

namespace ChessClock.Models
{
    [Serializable]
    public class ApiInputRequest
    {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("original_utterance")]
        public string OriginalUtterance { get; set; }

        [JsonProperty("type")]
        public UtteranceType Type { get; set; }

        [JsonProperty("markup")]
        public JObject Markup { get; set; }

        [JsonProperty("payload")]
        public JObject Payload { get; set; }

        [JsonProperty("nlu")]
        public ApiInputNLU NLU { get; set; }
    }
}
