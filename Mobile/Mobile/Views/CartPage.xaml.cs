using Xamarin.Forms;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class CartPage : ContentPage
    {
        CartViewModel _viewModel;
        public CartPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CartViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}