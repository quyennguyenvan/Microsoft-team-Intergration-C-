using System;
using Newtonsoft.Json;

namespace Teams
{
    public class PayloadMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
