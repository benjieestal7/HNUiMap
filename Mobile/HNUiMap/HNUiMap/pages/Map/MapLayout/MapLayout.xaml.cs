using HNUiMap.pages.Locations;
using HNUiMap.pages.PersonViewOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Map.MapLayout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapLayout : ContentPage
    {
        public MapLayout()
        {
            InitializeComponent();
            mapWebView.Source = new UrlWebViewSource { Url = "file:///android_asset/gps.html" };
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //Code here
        }
        
        async void LocationButton_Clicked(object sender, EventArgs e)
        {
            var personViewPage = new PersonViewPage();

            // Set the desired height for the half page
            personViewPage.HeightRequest = App.Current.MainPage.Height * 0.5;

            // Wrap the PersonViewPage in a NavigationPage to enable navigation features
            var navigationPage = new NavigationPage(personViewPage);

            // Set the modal presentation style to cover only half the screen on Android
            if (Device.RuntimePlatform == Device.Android)
            {
                navigationPage.SetValue(NavigationPage.HasNavigationBarProperty, false);
                navigationPage.SetValue(NavigationPage.TitleViewProperty, null);
                navigationPage.SetValue(NavigationPage.BackgroundColorProperty, Color.Transparent);
                navigationPage.SetValue(NavigationPage.PaddingProperty, new Thickness(0));
            }

            // Push the NavigationPage as a modal page
            await Navigation.PushModalAsync(navigationPage);
        }
        
        async void POVButton_Clicked(object sender, EventArgs e)
        {
            var locationsPage = new LocationsPage();

            // Set the desired height for the half page
            locationsPage.HeightRequest = App.Current.MainPage.Height * 0.5;

            // Wrap the LocationsPage in a NavigationPage to enable navigation features
            var navigationPage = new NavigationPage(locationsPage);

            // Set the modal presentation style to cover only half the screen on Android
            if (Device.RuntimePlatform == Device.Android)
            {
                navigationPage.SetValue(NavigationPage.HasNavigationBarProperty, false);
                navigationPage.SetValue(NavigationPage.TitleViewProperty, null);
                navigationPage.SetValue(NavigationPage.BackgroundColorProperty, Color.Transparent);
                navigationPage.SetValue(NavigationPage.PaddingProperty, new Thickness(0));
            }

            // Push the NavigationPage as a modal page
            await Navigation.PushModalAsync(navigationPage);
        }

        async private void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void OnSelectPhotoTapped(object sender, EventArgs e)
        {
            // Handle the logic to select a photo here
        }
    }
}
