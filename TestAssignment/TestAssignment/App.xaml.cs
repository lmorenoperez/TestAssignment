using System;
using TestAssignment.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestAssignment
{
    public partial class App : Application
    {
        public static string BackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://api.taxjar.com/v2" : "https://api.taxjar.com/v2";

        public static bool UseMockDataStore = true;
        public static string access_token = "5da2f821eee4035db4771edab942a4cc";
        public App()
        {
            InitializeComponent();
            if (UseMockDataStore)
                DependencyService.Register<MockTaxService>();
            else
                DependencyService.Register<TaxJarService>();

            MainPage = new MainPage();
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
