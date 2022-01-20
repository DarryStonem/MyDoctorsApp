using System;
namespace MyDoctors.Models
{
    public class DoctorViewModel
    {
        public Doctor Doctor { get; set; }

        public string ProfilePicture => Doctor?.Picture.Medium;

        public string DoctorFullName => $"{Doctor?.Name.First} {Doctor?.Name.Last}";

        public string Mail => Doctor?.Email;

        public string DoctorLocation => $"{Doctor?.Location.State}, {Doctor?.Location.Country}";

        public DoctorViewModel(Doctor doctor)
        {
            this.Doctor = doctor;
        }
    }
}