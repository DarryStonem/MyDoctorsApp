using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyDoctors.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        public async Task GoBack()
        {
            await (Application.Current.MainPage as ContentPage).Navigation.PopAsync();
        }

        public async Task NavigateAsync(Page page, bool animated = true)
        {
            await (Application.Current.MainPage as NavigationPage).Navigation.PushAsync(page);
        }
    }
}