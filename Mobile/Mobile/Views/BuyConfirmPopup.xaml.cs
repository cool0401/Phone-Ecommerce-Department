using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Android.Widget;
using static Android.Content.ClipData;

namespace Mobile.Views
{
    public partial class BuyConfirmPopup : Popup
    {
        public BuyConfirmPopup()
        {
            InitializeComponent();
        }

        private async void NextButtonClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayToastAsync("Buy Clicked", 2000);
        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            Dismiss("Dismiss");
            await Task.Delay(10);
        }
    }
}