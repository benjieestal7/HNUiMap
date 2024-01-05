using HNUiMap.pages.Announcement_List;
using HNUiMap.pages.Announcements;
using HNUiMap.pages.Announcements.MainAnnouncement;
using HNUiMap.pages.Profile;
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

namespace HNUiMap.pages.Drawer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrawerPageFlyout : ContentPage
    {
        public ListView ListView;

        public DrawerPageFlyout()
        {
            InitializeComponent();
           
            BindingContext = new DrawerPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class DrawerPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DrawerPageFlyoutMenuItem> MenuItems { get; set; }
            
            public DrawerPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<DrawerPageFlyoutMenuItem>(new[]
                {
                    new DrawerPageFlyoutMenuItem { Id = 0, Title = "Dashboard", TargetType=typeof(DashboardPage), IconSource = "home.png" },
                    new DrawerPageFlyoutMenuItem { Id = 1, Title = "Accounts" , TargetType=typeof(Profile.ProfilePage), IconSource = "profile.png" },
                    new DrawerPageFlyoutMenuItem { Id = 2, Title = "Announcements", TargetType=typeof(Announcements.AnnouncementPage), IconSource = "announcement.png" },
                    new DrawerPageFlyoutMenuItem { Id = 2, Title = "logout", TargetType=typeof(DashboardPage), IconSource = "logout.png" }

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