using System;
using System.Threading.Tasks;
using MyDoctors.Models;

namespace MyDoctors.Services
{
    public interface IDoctorsService
    {
        Task<DoctorsResult> GetDoctorsAsync();
    }
}