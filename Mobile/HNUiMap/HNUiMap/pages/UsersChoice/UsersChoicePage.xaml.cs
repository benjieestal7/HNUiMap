using HNUiMap.core;
using HNUiMap.pages.Announcement_List;
using HNUiMap.pages.Information;
using HNUiMap.pages.Map;
using HNUiMap.pages.Map.MapLayout;
using HNUiMap.pages.ScheduleList;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.UsersChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersChoicePage : ContentPage
    {
        public UsersChoicePage()
        {
            InitializeComponent();
        }

        async void BtnMap_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MapLayout());
        }

        async void BtnInfo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InformationPage());
        }

        async private void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void Btnmap_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                PublicVariables.AppForRestart = false;
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new MapPage());
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
            // Hide loading
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
