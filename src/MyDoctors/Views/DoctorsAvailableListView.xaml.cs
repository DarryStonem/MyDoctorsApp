using System;
using System.Collections.Generic;
using MyDoctors.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MyDoctors.Views
{
    public partial class DoctorsAvailableListView : ContentPage
    {
        public DoctorsAvailableListView()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasBackButton(this, false);
            On<iOS>().SetUseSafeArea(true);

            BindingContext = App.GetViewModel<DoctorsAvailableListViewModel>();
        }

        protected override void OnAppearing()
        {
            (BindingContext as BaseViewModel).InitializeViewModel();
        }
    }
}