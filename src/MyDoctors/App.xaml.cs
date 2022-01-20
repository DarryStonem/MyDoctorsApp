using System;
using Microsoft.Extensions.DependencyInjection;
using MyDoctors.Services;
using MyDoctors.Services.Implementation;
using MyDoctors.ViewModels;
using MyDoctors.Views;
using Xamarin.Forms;

namespace MyDoctors
{
    public partial class App : Application
    {
        protected static IServiceProvider ServiceContainer { get; set; }

        public static BaseViewModel GetViewModel<TViewModel>()
            where TViewModel : BaseViewModel => ServiceContainer.GetService<TViewModel>();

        public App(Action<IServiceCollection> deviceServices = null)
        {
            InitializeComponent();
            SetupServices(deviceServices);

            var mainPage = new NavigationPage(new LoginView());
            MainPage = mainPage;
        }

        /// <summary>
        /// Setup services for Dependency Injection
        /// </summary>
        /// <param name="deviceServices"></param>
        private void SetupServices(Action<IServiceCollection> deviceServices = null)
        {
            var services = new ServiceCollection();

            deviceServices?.Invoke(services);

            // ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<DoctorDetailViewModel>();
            services.AddTransient<DoctorsAvailableListViewModel>();

            // Services
            services.AddSingleton<IDoctorsService, DoctorsService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<INavigationService, NavigationService>();

            ServiceContainer = services.BuildServiceProvider();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
