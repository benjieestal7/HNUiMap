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
    public partial class NewAccomplishmentForm : ContentPage
    {
        public NewAccomplishmentForm()
        {
            InitializeComponent();
            btnSave.Clicked += BtnSave_Clicked;
            switchMain.Toggled += SwitchMain_Toggled;
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

        private void SwitchMain_Toggled(object sender, ToggledEventArgs e)
        {
            bool isOn = switchMain.IsToggled;
            DateControl(!isOn);
            if (isOn)
            {
                dtpFrom.Date = PublicVariables.ServerDate;
                dtpTo.Date = PublicVariables.ServerDate;
            }
            dateFrom = PublicVariables.ServerDate;
            dateTo = PublicVariables.ServerDate;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            btnSave.IsEnabled = false;
            if (!string.IsNullOrEmpty(txtAccomplishment.Text))
            {
                if (dateFrom <= dateTo)
                {
                    await ShowLoading("Saving...");
                    if (switchMain.IsToggled)
                    {
                        Accomplishments.Add(txtAccomplishment.Text, PublicVariables.ServerDate, PublicVariables.ServerDate);
                        if (Accomplishments.AddIsSuccessfull)
                        {
                            DisplayAlert("Accomplishment successfully saved!");
                            txtAccomplishment.Text = string.Empty;
                        }
                        else
                            DisplayAlert("Error saving accomplishment!\nPlease try again later.");
                    }
                    else
                    {
                        bool hasErrorSaving = false, hasWeekend = false, hasDataToSave = false;
                        foreach (DateTime day in EachDay(dateFrom, dateTo))
                        {
                            int dw = (int)day.DayOfWeek;
                            if (!dw.Equals(0) && !dw.Equals(6))
                            {
                                Accomplishments.Add(txtAccomplishment.Text, day, day);
                                if (!Accomplishments.AddIsSuccessfull)
                                    hasErrorSaving = true;
                                else
                                    hasDataToSave = hasDataToSave ? true : true;
                            }
                            else
                                hasWeekend = true;
                        }
                        if (hasWeekend)
                            DisplayAlert("Saturday and Sunday detected!\nAccomplishment on that day are not saved.");

                        if (!hasErrorSaving)
                        {
                            if (hasDataToSave)
                            {
                                DisplayAlert("Accomplishment successfully saved!");
                                txtAccomplishment.Text = string.Empty;
                            }
                            else
                                DisplayAlert("No data to be save!");
                        }
                        else
                            DisplayAlert("There are error(s) saving accomplishment!\nPlease check and try again later.");
                    }
                    await HideLoading();
                }
                else
                    DisplayAlert("Invalid date!");
            }
            else
                DisplayAlert("Cannot proceed without content!");
            btnSave.IsEnabled = true;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
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

            DateControl(false);
        }

        private void DateControl(bool stat)
        {
            lblToggle.TextColor = stat ? Color.Gray : Color.FromHex("#F2E8E9");
            lblFrom.IsVisible = stat;
            lblTo.IsVisible = stat;
            dtpFrom.IsVisible = stat;
            dtpTo.IsVisible = stat;
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