using System;
using MyDoctors.Services;

namespace MyDoctors.ViewModels
{
    public class BaseViewModel : MvvmHelpers.BaseViewModel
    {
        public INavigationService NavigationService { get; set; }

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void InitializeViewModel(object parameter = null)
        {

        }
    }
}