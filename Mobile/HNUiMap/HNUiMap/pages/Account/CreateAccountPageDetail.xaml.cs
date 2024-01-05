using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPageDetail : ContentPage
    {
        public CreateAccountPageDetail()
        {
            InitializeComponent();
        }
        private void OnSelectPhotoTapped(object sender, EventArgs e)
        {
            // Handle the logic to select a photo here
        }

    }
}