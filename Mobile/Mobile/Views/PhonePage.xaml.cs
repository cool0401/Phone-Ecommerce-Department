using Mobile.ViewModels;
using Xamarin.Forms;

namespace Mobile.Views
{
    public partial class PhonePage : ContentPage
    {
        PhoneViewModel _viewModel;

        public PhonePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PhoneViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}