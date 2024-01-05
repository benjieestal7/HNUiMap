using HNUiMap.pages.Announcement_List;
using HNUiMap.pages.Announcements.MainAnnouncement;
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

namespace HNUiMap.pages.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPageFlyout : ContentPage
    {
        public ListView ListView;

        public CreateAccountPageFlyout()
        {
            InitializeComponent();

            BindingContext = new CreateAccountPageFlyoutViewModel();
            ListView = MenuItemsListView;

        }

        private class CreateAccountPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<CreateAccountPageFlyoutMenuItem> MenuItems { get; set; }

            public CreateAccountPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<CreateAccountPageFlyoutMenuItem>(new[]
                {
                    new CreateAccountPageFlyoutMenuItem { Id = 0, Title = "Dashboard", TargetType=typeof(DashboardPage), IconSource = "home.png" },
                    new CreateAccountPageFlyoutMenuItem { Id = 1, Title = "Accounts" , TargetType=typeof(Profile.ProfilePage), IconSource = "profile.png" },
                    new CreateAccountPageFlyoutMenuItem { Id = 2, Title = "Announcements", TargetType=typeof(Announcements.AnnouncementPage), IconSource = "announcement.png" },
                    new CreateAccountPageFlyoutMenuItem { Id = 2, Title = "logout", TargetType=typeof(DashboardPage), IconSource = "logout.png" }
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