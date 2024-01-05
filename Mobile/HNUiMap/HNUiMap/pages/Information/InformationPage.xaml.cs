using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Information
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationPage : ContentPage
    {
        public List<string> SampleTexts { get; set; }

        public InformationPage()
        {
            InitializeComponent();

            SampleTexts = new List<string>
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
        async private void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}