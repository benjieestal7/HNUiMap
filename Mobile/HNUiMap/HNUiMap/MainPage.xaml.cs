using System;
using System.Linq;
using Xamarin.Forms;
using HNUiMap.pages;
using HNUiMap.core;
using HNUiMap.api;
using System.Threading.Tasks;

namespace HNUiMap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnMyAccomplishment.Clicked += BtnMyAccomplishment_Clicked;
            btnNewAccomlishment.Clicked += BtnNewAccomlishment_Clicked;
            btnEditInfo.Clicked += BtnEditInfo_Clicked;
            btnDeleteAccount.Clicked += BtnDeleteUser_Clicked;
            btnLogout.Clicked += BtnLogout_Clicked;
        }

        private void BtnLogout_Clicked(object sender, EventArgs e)
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert(PublicVariables.ProjectName, "Confirm logout?", "Yes", "No");
                if (result)
                    ForceLogout();
            });
        }

        private void ForceLogout()
        {
            PublicVariables.UserIsDoneLogin = false;
            oneTimeShow = false;
            OpenLogin();
        }

        private void BtnEditInfo_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                PublicVariables.AppForRestart = false;
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new EditInfoPage());
            });
        }

        private void BtnNewAccomlishment_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new NewAccomplishmentForm());
            });
        }

        private async void BtnDeleteUser_Clicked(object sender, EventArgs e)
        {

            var result = await this.DisplayAlert(PublicVariables.ProjectName, "Do you want to delete your account?", "Yes", "No");
            if (result)
                DisplayAlert(Employee.DeleteUser(PublicVariables.UserId));

            if (Employee.DeleteUserIsSuccessfull)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //Navigation.PushAsync(new MainPage());
                    var currentPage = GetCurrentPage();
                    await currentPage.Navigation.PushAsync(new LoginPage());
                });

            }
       }

        private Task HideLoading()
        {
            throw new NotImplementedException();
        }

        private void BtnMyAccomplishment_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new MyAccomplishmentForm());
            });
        }

        private int oneTimeLoginCount = 0;
        public static string UsersFullname = string.Empty;
        private bool oneTimeShow = false;
        protected override void OnAppearing()
        {
            if (!PublicVariables.UserIsDoneLogin)
            {
                if (oneTimeLoginCount.Equals(0))
                {
                    oneTimeLoginCount++;
                    OpenLogin();
                }
                else
                {
                    PublicVariables.UserIsDoneLogin = false;
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                    Navigation.PopToRootAsync();
                }
            }
            else
            {
                if (!oneTimeShow)
                {
                    //done login here!
                    oneTimeShow = true;
                    string alert = "Welcome back " + UsersFullname + "!";
                    DisplayAlert(alert);
                }
            }
            if (PublicVariables.AppForRestart)
                ForceLogout();
        }

        private void OpenLogin()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new LoginPage());
            });
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async() =>
            {
                var result = await this.DisplayAlert(PublicVariables.ProjectName, "Do you really want to exit?", "Yes", "No");
                if (result)
                {
                    PublicVariables.UserIsDoneLogin = false;
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                    await this.Navigation.PopToRootAsync();
                }
            });

            return true;
        }

        private void DisplayAlert(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(PublicVariables.ProjectName, message, "OK");
            });
        }

        private Page GetCurrentPage()
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            return currentPage;
        }
    }
}
