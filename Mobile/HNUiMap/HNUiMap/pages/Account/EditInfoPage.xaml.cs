using HNUiMap.api;
using HNUiMap.core;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditInfoPage : ContentPage
	{
		public EditInfoPage ()
		{
			InitializeComponent ();
            btnSave.Clicked += BtnSave_Clicked;

            txtNewFullname.Text = UsersFullname;
            txtNewDesignation.Text = UsersDesignation;
            txtNewUsername.Text = UsersUsername;
            txtNewDivision.Text = UsersDivision;
        }

        public static string UsersFullname = string.Empty;
        public static string UsersDesignation = string.Empty;
        public static string UsersUsername = string.Empty;
        public static string UsersDivision = string.Empty;

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCurrentPassword.Text) && !string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (PublicVariables.UserPassword.Equals(txtCurrentPassword.Text))
                {
                    if (txtNewPassword.Text.Equals(txtConfirmPassword.Text))
                    {
                        if (!txtCurrentPassword.Text.Equals(txtNewPassword.Text))
                        {
                            await ShowLoading("Saving information...");
                            //saving password here...
                            Employee.EditInfo(txtNewFullname.Text, txtNewDesignation.Text, txtNewUsername.Text, txtNewDivision.Text, txtNewPassword.Text, PublicVariables.UserId);

                            if (Employee.EditInfoIsSuccessfull)
                            {
                                PublicVariables.AppForRestart = true;
                                await HideLoading();
                                await Navigation.PopAsync();
                            }
                            else
                                DisplayMessageAlert("Error updating your password!\nPlease check your connection and try again!");
                        }
                        else
                            DisplayMessageAlert("New password must not be the same with the current password!");
                    }
                    else
                        DisplayMessageAlert("New password and confirm password mismatch!");
                }
                else
                    DisplayMessageAlert("Current password incorrect!");
            }
            else
                DisplayMessageAlert("Please fill all the text fields!");
        }

        private void DisplayMessageAlert(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(PublicVariables.ProjectName, message, "OK");
            });
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
    }
}