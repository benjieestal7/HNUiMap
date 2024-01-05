using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Profile.EditProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePageDetail : ContentPage
    {
        public EditProfilePageDetail()
        {
            InitializeComponent();
        }
        private void OnSelectPhotoTapped(object sender, EventArgs e)
        {
            // Handle the logic to select a photo here
        }
    }
}