using System;
using Newtonsoft.Json;

namespace MyDoctors.Models
{
    public class DoctorLocation
    {
        [JsonProperty("street")]
        public LocationStreet Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postcode")]
        public object Postcode { get; set; }

        [JsonProperty("coordinates")]
        public LocationCoordinates Coordinates { get; set; }

        [JsonProperty("timezone")]
        public LocationTimezone Timezone { get; set; }
    }
}
