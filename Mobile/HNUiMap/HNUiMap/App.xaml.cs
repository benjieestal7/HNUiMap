using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HNUiMap.pages;
using HNUiMap.pages.AppStartUp;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HNUiMap
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new LandingPage())
            {
                BarBackgroundColor = Color.FromHex("#0E0E19"),
                BarTextColor = Color.FromHex("F2E8E9")
            };

            //var tabPage = new TabbedPage();
            //tabPage.Children.Add(new MainPage());
            //tabPage.Children.Add(new NewAccomplishmentForm());
            //MainPage = new TabbedPage();
            //MainPage = tabPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
