using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyDoctors.Models
{
    public class DoctorsResult
    {
        [JsonProperty("results")]
        public List<Doctor> Results { get; set; }

        [JsonProperty("info")]
        public ApiInfo Info { get; set; }
    }

    public class ApiInfo
    {
        [JsonProperty("seed")]
        public string Seed { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
