using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ChessClock.Models
{
    [Serializable]
    public class ApiInputEntity
    {
        [JsonProperty("tokens")]
        public ApiInputToken Token { get; set; }

        [JsonProperty("type")]
        //TODO: enum for different types
        public string Type { get; set; }

        [JsonProperty("value")]
        //TODO: go through the "Named Entities in the Queries" at Dialogues API and define possible values
        public JObject Value { get; set; }
    }
}
