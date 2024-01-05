using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Feedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }
        async void BtnRate_Clicked(object sender, EventArgs e)
        {
           //code here
        }
        private void StarRating_RatingSelected(object sender, int rating)
        {
            // Handle the selected rating here
            // You can save the rating, display it, or perform any desired action
        }
        private async void ShowPopupButton_Clicked(object sender, EventArgs e)
        {
            var popup = new SendRatingScale(); // Instantiate your custom popup page
            await PopupNavigation.Instance.PushAsync(popup);
        }
    }
}