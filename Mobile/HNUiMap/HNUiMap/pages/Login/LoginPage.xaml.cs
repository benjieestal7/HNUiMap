using HNUiMap.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data;
using HNUiMap.api;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using HNUiMap.pages.Drawer;
using HNUiMap.pages.Account;
using HNUiMap.pages.ScheduleList;

namespace HNUiMap.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            btnLogin.Clicked += BtnLogin_ClickedAsync;
            btnRegister.Clicked += BtnCreateUser_Clicked;
        }

        private async void BtnLogin_ClickedAsync(object sender, EventArgs e)
        {
            btnLogin.IsEnabled = false;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                await ShowLoading("Logging in...");
                DataTable loginData = Employee.Login(username, password);
                await HideLoading();

                if (loginData != null && loginData.Rows.Count > 0)
                {
                    PublicVariables.UserPassword = password;
                    PublicVariables.UserName = username;
                    // PublicVariables.ServerDate = Convert.ToDateTime(loginData.Rows[0]["server_date"]);
                    //PublicVariables.UserId = Convert.ToInt32(loginData.Rows[0]["id"]);

                    string usersFullname = loginData.Rows[0]["name"].ToString();
                //    string usersDesignation = loginData.Rows[0]["designation"].ToString();
                  //  string usersUsername = loginData.Rows[0]["id_number"].ToString();
                  //  string usersDivision = loginData.Rows[0]["division"].ToString();

                    string alert = "Welcome back " + usersFullname + "!";
                    //DisplayAlert(alert);
                    SpeakNowDefaultSettings(alert);
                    MainPage.UsersFullname = usersFullname;
        
                    EditInfoPage.UsersFullname = usersFullname;
                    //EditInfoPage.UsersDesignation = usersDesignation;
                    //EditInfoPage.UsersUsername = usersUsername;
                   // EditInfoPage.UsersDivision = usersDivision;

                    PublicVariables.UserIsDoneLogin = true;
                    PublicVariables.AppForRestart = false;
                    var currentPage = GetCurrentPage();
                    await currentPage.Navigation.PushAsync(new DrawerPage());
                }
                else
                    DisplayMessageAlert("Invalid login credentials!\nPlease try again.");

            }
            else
            {
                PublicVariables.UserIsDoneLogin = false;
                await DisplayAlert(PublicVariables.ProjectName, "Please provide username and or password", "OK");
            }
            btnLogin.IsEnabled = true;
        }

        private void BtnCreateUser_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                PublicVariables.AppForRestart = false;
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new CreateAccountPage());
            });
        }
        private Page GetCurrentPage()
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            return currentPage;
        }
        public void SpeakNowDefaultSettings(string message)
        {
            try
            {
                TextToSpeech.SpeakAsync(message).ContinueWith(async (t) =>
                {
                    // Logic that will run after utterance finishes.
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch { }
        }

        private static async Task HideLoading()
        {
            //hide loading
            await PopupNavigation.Instance.PopAsync();
        }

        private static async Task ShowLoading(string message)
        {
            //show loading
            LoadingPage loadingPage = new LoadingPage();
            loadingPage.Message = message;
            await PopupNavigation.Instance.PushAsync(loadingPage);
        }

        private void DisplayMessageAlert(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(PublicVariables.ProjectName, message, "OK");
            });
        }
    }
}