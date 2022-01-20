using System;
using Newtonsoft.Json;

namespace MyDoctors.Models
{
    public class LocationCoordinates
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
