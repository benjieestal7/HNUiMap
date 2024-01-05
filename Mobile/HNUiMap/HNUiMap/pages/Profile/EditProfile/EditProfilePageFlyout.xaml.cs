using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages.Profile.EditProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePageFlyout : ContentPage
    {
        public ListView ListView;

        public EditProfilePageFlyout()
        {
            InitializeComponent();

            BindingContext = new EditProfilePageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class EditProfilePageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<EditProfilePageFlyoutMenuItem> MenuItems { get; set; }
            
            public EditProfilePageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<EditProfilePageFlyoutMenuItem>(new[]
                {
                    new EditProfilePageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new EditProfilePageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new EditProfilePageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new EditProfilePageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new EditProfilePageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}