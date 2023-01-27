using Mobile.ViewModels;
using Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    public partial class NewContactPage : ContentPage
    {
        public Contact Item { get; set; }

        public NewContactPage()
        {
            InitializeComponent();
            BindingContext = new NewContactViewModel();
        }
    }
}