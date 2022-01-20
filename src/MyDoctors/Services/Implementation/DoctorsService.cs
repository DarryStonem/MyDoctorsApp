using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyDoctors.Models;
using Newtonsoft.Json;

namespace MyDoctors.Services.Implementation
{
    public class DoctorsService : IDoctorsService
    {
        /// <summary>
        /// Get Doctors List from the API
        /// </summary>
        /// <returns></returns>
        public async Task<DoctorsResult> GetDoctorsAsync()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://randomuser.me/api/?results=5");

            if(result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DoctorsResult>(json);
            }
            else
            {
                return new DoctorsResult() { Results = new List<Doctor>() };
            }
        }
    }
}
