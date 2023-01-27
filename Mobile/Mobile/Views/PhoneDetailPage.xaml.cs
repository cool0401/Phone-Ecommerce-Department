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
    public partial class PhoneDetailPage : ContentPage
    {
        public PhoneDetailPage()
        {
            InitializeComponent();
            BindingContext = new PhoneDetailViewModel();
        }
    }
}