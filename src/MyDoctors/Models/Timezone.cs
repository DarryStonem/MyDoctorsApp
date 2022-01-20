using System;
using Newtonsoft.Json;

namespace MyDoctors.Models
{
    public class LocationTimezone
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
