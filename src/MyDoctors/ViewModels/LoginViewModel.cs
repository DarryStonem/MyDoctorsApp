using System;
using System.Windows.Input;
using MyDoctors.Services;
using MyDoctors.Utils;
using MyDoctors.Views;
using Xamarin.Forms;
namespace MyDoctors.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Private Properties

        private string username;
        private string password;

        #endregion

        #region Public properties

        public string Username
        {
            get => username ?? null;
            set => SetProperty(ref username, value);
        }


        public string Password
        {
            get => password ?? null;
            set => SetProperty(ref password, value);
        }

        #endregion

        public ICommand LoginCommand
        {
            get
            {
                return new Command(ExecuteLoginCommand);
            }
        }

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        private async void ExecuteLoginCommand()
        {
            var errorMessage = string.Empty;
            if(String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
            {
                errorMessage = "Invalid User or Password";
            }

            if(!StringHelpers.IsValidEmail(Username))
            {
                errorMessage = "Invalid email format";
            }

            if(String.IsNullOrEmpty(errorMessage))
            {
                if (Username == "user@mail.com" && Password == "pass1234")
                {
                    await NavigationService.NavigateAsync(new DoctorsAvailableListView());
                    return;
                }
                else
                {
                    errorMessage = "You don't have the right permissions";
                }
            }

            await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "Ok");
        }
    }
}