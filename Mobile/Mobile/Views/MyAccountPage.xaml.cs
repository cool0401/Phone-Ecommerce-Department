using Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    public partial class MyAccountPage : ContentPage
    {
        AccoutViewModel _viewModel;
        public MyAccountPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AccoutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}