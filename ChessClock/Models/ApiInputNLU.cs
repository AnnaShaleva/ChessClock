using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ChessClock.Models
{
    [Serializable]
    public class ApiInputNLU
    {
        [JsonProperty("tokens")]
        public IEnumerable<string> Tokens { get; set; }

        //TODO: 
        //[JsonProperty("entities")]
        //public IEnumerable<ApiInputEntity> Entities { get; set; }

        [JsonProperty("entities")]
        public IEnumerable<JObject> Entities { get; set; }
    }
}
