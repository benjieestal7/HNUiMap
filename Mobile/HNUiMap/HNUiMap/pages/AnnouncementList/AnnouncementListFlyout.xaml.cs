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

namespace HNUiMap.pages.Announcement_List
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnnouncementListFlyout : ContentPage
    {
        public ListView ListView;

        public AnnouncementListFlyout()
        {
            InitializeComponent();

            BindingContext = new AnnouncementListFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class AnnouncementListFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AnnouncementListFlyoutMenuItem> MenuItems { get; set; }

            public AnnouncementListFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<AnnouncementListFlyoutMenuItem>(new[]
                {
                    new AnnouncementListFlyoutMenuItem { Id = 0, Title = "Dashboard", TargetType=typeof(DashboardPage), IconSource = "home.png" },
                    new AnnouncementListFlyoutMenuItem { Id = 1, Title = "Accounts" , TargetType=typeof(Profile.ProfilePage), IconSource = "profile.png" },
                    new AnnouncementListFlyoutMenuItem { Id = 2, Title = "Announcements", TargetType=typeof(Announcements.AnnouncementPage), IconSource = "announcement.png" },
                    new AnnouncementListFlyoutMenuItem { Id = 2, Title = "logout", TargetType=typeof(DashboardPage), IconSource = "logout.png" }
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