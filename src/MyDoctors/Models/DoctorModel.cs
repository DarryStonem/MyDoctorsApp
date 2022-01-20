using System;
using Newtonsoft.Json;

namespace MyDoctors.Models
{
    public class Doctor
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("location")]
        public DoctorLocation Location { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("picture")]
        public ProfilePicture Picture { get; set; }

        [JsonProperty("nat")]
        public string Nat { get; set; }
    }
}