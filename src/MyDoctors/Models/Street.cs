using System;
using Newtonsoft.Json;

namespace MyDoctors.Models
{
    public class LocationStreet
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Number}, {Name}";
        }
    }
}
