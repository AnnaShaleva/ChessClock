using Newtonsoft.Json;
using System;

namespace ChessClock.Models
{
    [Serializable]
    public class ApiInputSession
    {
        [JsonProperty("new")]
        public bool New { get; set; }

        [JsonProperty("message_id")]
        public int MessageId;

        [JsonProperty("session_id")]
        public string SessionId;

        [JsonProperty("skill_id")]
        public string SkillId;

        [JsonProperty("user_id")]
        public string UserId;
    }
}
