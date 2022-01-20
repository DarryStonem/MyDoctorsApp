using System;
using System.Collections.Generic;
using MyDoctors.Models;
using MyDoctors.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MyDoctors.Views
{
    public partial class DoctorDetailView : ContentPage
    {
        private DoctorViewModel selectedDoctor;

        public DoctorDetailView()
        {
            InitializeDetailView();
        }

        public DoctorDetailView(DoctorViewModel parameter)
        {
            InitializeDetailView();
            selectedDoctor = parameter;
        }

        protected override void OnAppearing()
        {
            (BindingContext as BaseViewModel).InitializeViewModel(selectedDoctor);

            ShowMapPosition();
        }

        /// <summary>
        /// Sometimes the service returns a random location so it displays the sea. 
        /// </summary>
        private void ShowMapPosition()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                Position position = new Position(selectedDoctor.Doctor.Location.Coordinates.Latitude,
                selectedDoctor.Doctor.Location.Coordinates.Longitude);
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.444));

                Pin pin = new Pin
                {
                    Label = selectedDoctor.DoctorFullName,
                    Address = selectedDoctor.DoctorLocation,
                    Type = PinType.Place,
                    Position = position
                };
                map.Pins.Add(pin);

                map.MoveToRegion(mapSpan);

                return false;
            });
        }

        private void InitializeDetailView()
        {
            InitializeComponent();

            On<iOS>().SetUseSafeArea(true);
            Xamarin.Forms.NavigationPage.SetBackButtonTitle(this, "");

            BindingContext = App.GetViewModel<DoctorDetailViewModel>();
        }
    }
}