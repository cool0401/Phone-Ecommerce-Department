using Mobile.ViewModels;
using Mobile.Views;
using System;
using Xamarin.Forms;

namespace Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactDetailPage), typeof(ContactDetailPage));
            Routing.RegisterRoute(nameof(NewContactPage), typeof(NewContactPage));
            Routing.RegisterRoute(nameof(PhoneDetailPage), typeof(PhoneDetailPage));
            Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));
            Routing.RegisterRoute(nameof(EditMyAccountPage), typeof(EditMyAccountPage));
        }
    }
}
