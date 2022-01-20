using System;
using Newtonsoft.Json;

namespace MyDoctors.Models
{
    public class ProfilePicture
    {
        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
