using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }


        private void OnLabelClicked1(object sender, EventArgs e)
        {
            // handle the label click event for label 1 here
        }

        private void OnLabelClicked2(object sender, EventArgs e)
        {
            // handle the label click event for label 2 here
        }

        private void OnLabelClicked3(object sender, EventArgs e)
        {
            // handle the label click event for label 3 here
        }
        private void OnLabelClicked4(object sender, EventArgs e)
        { 
            // handle the label click event for label 3 here
        }
        private void StarRating_RatingSelected(object sender, int rating)
        {
            // Handle the selected rating here
            // You can save the rating, display it, or perform any desired action
        }

    }
}
