using HNUiMap.core;
using HNUiMap.pages.Feedback;
using HNUiMap.pages.UsersChoice;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.AppStartUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LandingPage : ContentPage
	{
		public LandingPage ()
		{
			InitializeComponent ();
            btnNxtLogin.Clicked += BtnLoginPage_Clicked;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FeedbackPage());
        }

        private void BtnLoginPage_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                PublicVariables.AppForRestart = false;
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new LoginPage());
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
    }
}