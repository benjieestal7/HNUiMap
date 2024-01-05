using HNUiMap.core;
using HNUiMap.pages.Announcement_List;
using HNUiMap.pages.Profile.EditProfile;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Profile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : MasterDetailPage
	{
        public List<string> ProfileData { get; set; }
        public ProfilePage ()
		{
			InitializeComponent ();
            //btnCreateAdmin.Clicked += OnEditProfileTapped;

            ProfileData = new List<string>
            {
                "Sample Text 1",
                "Sample Text 2",
                "Sample Text 3",
                "Sample Text 4",
                "Sample Text 5",
                "Sample Text 6",
                "Sample Text 7",
                "Sample Text 8",
                "Sample Text 9",
                "Sample Text 10",
                "Sample Text 11",
                "Sample Text 12",
                "Sample Text 13",
                "Sample Text 14",
                "Sample Text 15",
                // Add more sample texts as needed
            };

            BindingContext = this;
        }
        private void OnSelectPhotoTapped(object sender, EventArgs e)
        {
            // Handle the logic to select a photo here
        }
        private void OnEditProfileTapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                PublicVariables.AppForRestart = false;
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new EditProfilePage());
            });
        }

        private void BtnCreateAdmin_Clicked(object sender, EventArgs e)
        {
            // Handle the logic to select a photo here
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
                TextToSpeech.SpeakAsync(message).ContinueWith((t) => {
                    return Task.CompletedTask;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch { }
        }
        private static async Task HideLoading()
        {
            //hide loading
            await PopupNavigation.Instance.PopAsync();
        }

    }
}