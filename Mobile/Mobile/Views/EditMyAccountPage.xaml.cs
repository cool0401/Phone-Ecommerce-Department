using Mobile.ViewModels;
using Xamarin.Forms;

namespace Mobile.Views
{
    public partial class EditMyAccountPage : ContentPage
    {
        public EditMyAccountPage()
        {
            InitializeComponent();
            BindingContext = new EditMyAccountViewModel();
        }
    }
}