using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using MyDoctors.Models;
using MyDoctors.Services;
using Xamarin.Forms;

namespace MyDoctors.ViewModels
{
    public class DoctorDetailViewModel : BaseViewModel
    {
        #region Private Properties

        private DoctorViewModel selectedDoctor;

        #endregion

        #region Public Properties

        public DoctorViewModel SelectedDoctor
        {
            get => selectedDoctor ?? null;
            set => SetProperty(ref selectedDoctor, value);
        }

        public ICommand CallCommand
        {
            get
            {
                return new Command(ExecuteCallCommand);
            }
        }

        #endregion

        public DoctorDetailViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void InitializeViewModel(object parameter = null)
        {
            base.InitializeViewModel(parameter);
            if(parameter != null)
            {
                SelectedDoctor = parameter as DoctorViewModel;
            }
        }

        private void ExecuteCallCommand()
        {
            try
            {
                var phone = Regex.Match(SelectedDoctor.Doctor.Phone, @"\d+").Value;
                Xamarin.Essentials.PhoneDialer.Open(phone);
            }
            catch (Exception ex)
            {
                // Running in emulator may crash
            }
        }
    }
}