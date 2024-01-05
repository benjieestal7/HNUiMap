using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Locations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {

        // Define the collections for dropdown items
        public ObservableCollection<string> EnrollmentItems { get; set; }
        public ObservableCollection<string> BillingsItems { get; set; }
        public ObservableCollection<string> SuppliesItems { get; set; }
        public ObservableCollection<string> RecordsItems { get; set; }

        // Custom property for the height of the collection views
        public double EnrollmentCollectionViewHeight => EnrollmentItems.Count * 50; // Adjust the height as desired
        public double BillingsCollectionViewHeight => BillingsItems.Count * 50; // Adjust the height as desired
        public double SuppliesCollectionViewHeight => SuppliesItems.Count * 50; // Adjust the height as desired
        public double RecordsCollectionViewHeight => RecordsItems.Count * 50; // Adjust the height as desired

        public LocationsPage()
        {
            InitializeComponent();

            // Initialize the collections and populate with items
            EnrollmentItems = new ObservableCollection<string>
            {
                "Tertiary Enrollment",
                "Basic Education Enrollment"
            };

            BillingsItems = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };

            SuppliesItems = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };

            RecordsItems = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };

            // Set the data context for the page to enable data binding
            BindingContext = this;
        }

        // Event handler for the selection changed event of the enrollmentCollectionView
        private void EnrollmentCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event here
            var selectedValue = (string)e.CurrentSelection.FirstOrDefault();
            // Do something with the selected value
        }

        // Event handler for the selection changed event of the billingsCollectionView
        private void BillingsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event here
            var selectedValue = (string)e.CurrentSelection.FirstOrDefault();
            // Do something with the selected value
        }

        // Event handler for the selection changed event of the suppliesCollectionView
        private void SuppliesCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event here
            var selectedValue = (string)e.CurrentSelection.FirstOrDefault();
            // Do something with the selected value
        }

        // Event handler for the selection changed event of the recordsCollectionView
        private void RecordsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event here
            var selectedValue = (string)e.CurrentSelection.FirstOrDefault();
            // Do something with the selected value
        }

        // Button click event handler for btnenrollment
        private void BtnEnrollment_Clicked(object sender, EventArgs e)
        {
            enrollmentCollectionView.IsVisible = !enrollmentCollectionView.IsVisible;
        }

        // Button click event handler for btnbillings
        private void BtnBillings_Clicked(object sender, EventArgs e)
        {
            billingsCollectionView.IsVisible = !billingsCollectionView.IsVisible;
        }

        // Button click event handler for btnsupplies
        private void BtnSupplies_Clicked(object sender, EventArgs e)
        {
            suppliesCollectionView.IsVisible = !suppliesCollectionView.IsVisible;
        }

        // Button click event handler for btnrecords
        private void BtnRecords_Clicked(object sender, EventArgs e)
        {
            recordsCollectionView.IsVisible = !recordsCollectionView.IsVisible;
        }
    
        private void EnrollmentCollectionView_SelectionChanged(object sender, EventArgs e)
        {
            // Handle the selected index changed event of the enrollmentPicker here
            // You can access the selected item using enrollmentPicker.SelectedItem
        }
        private void BillingsCollectionView_SelectionChanged(object sender, EventArgs e)
        {
            // Handle the selected index changed event of the enrollmentPicker here
            // You can access the selected item using enrollmentPicker.SelectedItem
        }
        private void SuppliesCollectionView_SelectionChanged(object sender, EventArgs e)
        {
            // Handle the selected index changed event of the enrollmentPicker here
            // You can access the selected item using enrollmentPicker.SelectedItem
        }
        private void RecordsCollectionView_SelectionChanged(object sender, EventArgs e)
        {
            // Handle the selected index changed event of the enrollmentPicker here
            // You can access the selected item using enrollmentPicker.SelectedItem
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //Code here
        }
        private void ItemButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var selectedItem = button.Text;
            // Do something with the selected item
        }


        //private void BtnEnrollment_Clicked(object sender, EventArgs e)
        //{
        //    //Code here
        //}
        //private void BtnBillings_Clicked(object sender, EventArgs e)
        //{
        //    //Code here
        //}
        //private void BtnSupplies_Clicked(object sender, EventArgs e)
        //{
        //    //Code here
        //}
        //private void BtnRecords_Clicked(object sender, EventArgs e)
        //{
        //    //Code here
        //}
    }
}