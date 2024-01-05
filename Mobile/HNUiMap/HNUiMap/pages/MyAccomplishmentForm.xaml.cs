using HNUiMap.api;
using HNUiMap.core;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace HNUiMap.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccomplishmentForm : ContentPage
    {
        public MyAccomplishmentForm()
        {
            InitializeComponent();
            btnLoad.Clicked += BtnLoad_Clicked;
            dtpFrom.DateSelected += DtpFrom_DateSelected;
            dtpTo.DateSelected += DtpTo_DateSelected;
        }

        DateTime dateFrom = new DateTime();
        DateTime dateTo = new DateTime();
        private void DtpTo_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateTo = e.NewDate;
        }

        private void DtpFrom_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateFrom = e.NewDate;
        }

        private async void BtnLoad_Clicked(object sender, EventArgs e)
        {
            if (dateFrom <= dateTo)
            {
                await ShowLoading("Loading data...");
                DataTable data = new DataTable();
                data = Accomplishments.Get(dateFrom, dateTo, PublicVariables.UserId);
                await HideLoading();

                //populate data
                if (data != null && data.Rows.Count > 0)
                {
                    var itemList = new ObservableCollection<string>();
                    for(int i =0;i<data.Rows.Count; i++)
                    {
                        string displayAccomp = data.Rows[i]["display"].ToString();
                        string dateAccomp = Convert.ToDateTime(data.Rows[i]["accomplishment_date"]).ToShortDateString();
                        string accomplishment = data.Rows[i]["accomplishment_name"].ToString();
                        string accompDate = Convert.ToDateTime(data.Rows[i]["accomplishment_date"]).ToMySQLDateFormat();
                        string dw = DateTime.Parse(dateAccomp, CultureInfo.InvariantCulture).ToString("ddd").ToUpper();
                        //string to dis
                        string finalStr = string.Concat(accompDate, " (", dw, ") - ", accomplishment);
                        itemList.Add(finalStr);
                        listviewAccomplishments.ItemsSource = itemList;
                    }
                }
                else
                    DisplayAlert("No data!");
            }
            else
                DisplayAlert("Invalid date!");
        }

        private void DisplayAlert(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(PublicVariables.ProjectName, message, "OK");
            });
        }

        protected override void OnAppearing()
        {
            dtpFrom.Date = PublicVariables.ServerDate;
            dtpTo.Date = PublicVariables.ServerDate;

            dateFrom = PublicVariables.ServerDate;
            dateTo = PublicVariables.ServerDate;
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