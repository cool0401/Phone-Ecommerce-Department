using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    public partial class CheckoutPage : ContentPage
    {
        CheckoutViewModel _viewModel;
        public CheckoutPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CheckoutViewModel();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}