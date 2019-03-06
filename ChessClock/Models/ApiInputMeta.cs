using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ChessClock.Models
{
    [Serializable]
    public class ApiInputMeta
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("interfaces")]
        //TODO: define screen interface
        //public IEnumerable<ApiInputInterface> Interfaces { get; set; }
        public JObject Interfaces { get; set; }
    }
}
