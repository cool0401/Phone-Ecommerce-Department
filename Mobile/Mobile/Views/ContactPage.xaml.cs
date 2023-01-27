using Mobile.ViewModels;
using Xamarin.Forms;

namespace Mobile.Views
{
    public partial class ContactPage : ContentPage
    {
        ContactViewModel _viewModel;

        public ContactPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ContactViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}