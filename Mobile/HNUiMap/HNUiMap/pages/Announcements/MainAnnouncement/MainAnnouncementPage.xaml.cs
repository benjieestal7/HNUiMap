using HNUiMap.core;
using HNUiMap.pages.Account;
using HNUiMap.pages.Map;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data;
using HNUiMap.api;
using Xamarin.Essentials;
using HNUiMap.pages.Announcement_List;
using HNUiMap.pages.ScheduleList;

namespace HNUiMap.pages.Announcements.MainAnnouncement
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainAnnouncementPage : ContentPage
	{
        public List<string> AnnouncementData { get; set; }
        public MainAnnouncementPage()
		{
			InitializeComponent();
            //btnCreate.Clicked += BtnCreateAnnouncement_Clicked;
            //btnSchedList.Clicked += BtnCreateScheduleList_Clicked; 

            AnnouncementData = new List<string>
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
        private void BtnCreateAnnouncement_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                PublicVariables.AppForRestart = false;
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new AnnouncementList());
            });
        }

        private void BtnCreateScheduleList_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                PublicVariables.AppForRestart = false;
                //Navigation.PushAsync(new MainPage());
                var currentPage = GetCurrentPage();
                await currentPage.Navigation.PushAsync(new ScheduleListPage());
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