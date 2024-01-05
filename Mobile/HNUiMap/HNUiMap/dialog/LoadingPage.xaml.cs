using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HNUiMap.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingPage : PopupPage
    {
        public string Message = string.Empty;
		public LoadingPage ()
		{
			InitializeComponent();
        }

        protected override void OnAppearing()
        {
            lblMessage.Text = Message;
        }
    }
}