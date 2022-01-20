using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyDoctors.Models;
using MyDoctors.Services;
using MyDoctors.Views;
using Xamarin.Forms;

namespace MyDoctors.ViewModels
{
    public class DoctorsAvailableListViewModel : BaseViewModel
    {
        #region Private Properties

        private ObservableCollection<DoctorViewModel> doctorsList;
        private DoctorViewModel selectedDoctor;

        private IDoctorsService DoctorsService;

        #endregion

        #region Public Properties

        public ObservableCollection<DoctorViewModel> DoctorsList
        {
            get => doctorsList ?? null;
            set => SetProperty(ref doctorsList, value);
        }

        public DoctorViewModel SelectedDoctor
        {
            get => selectedDoctor ?? null;
            set => SetProperty(ref selectedDoctor, value);
        }

        #endregion

        public ICommand SelectedItemCommand
        {
            get
            {
                return new Command<DoctorViewModel>(ExecuteSelectedItemCommand);
            }
        }

        private async void ExecuteSelectedItemCommand(object obj)
        {
            if(SelectedDoctor != null)
            {
                // navigate to the next view
                await NavigationService.NavigateAsync(new DoctorDetailView(SelectedDoctor));
                SelectedDoctor = null;
            }
        }

        public DoctorsAvailableListViewModel(INavigationService navigationService, IDoctorsService doctorsService) : base(navigationService)
        {
            DoctorsService = doctorsService;
        }

        public async override void InitializeViewModel(object parameter = null)
        {
            IsBusy = false;
            base.InitializeViewModel(parameter);
            await InitializeDoctors();
        }

        private async Task InitializeDoctors()
        {
            IsBusy = true;
            if (DoctorsList == null)
            {
                DoctorsList = new ObservableCollection<DoctorViewModel>();
            }
            else
            {
                DoctorsList.Clear();
            }

            try
            {
                var results = await DoctorsService.GetDoctorsAsync();
                if(results?.Results == null)
                {
                    IsBusy = false;
                    return;
                }

                foreach (var item in results.Results)
                {
                    DoctorsList.Add(new DoctorViewModel(item));
                }
            }
            catch (Exception ex)
            {
                // Display error to the user
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}