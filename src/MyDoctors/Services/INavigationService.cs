using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyDoctors.Services
{
    public interface INavigationService
    {
        Task GoBack();
        Task NavigateAsync(Page pageKey, bool animated = true);
    }
}