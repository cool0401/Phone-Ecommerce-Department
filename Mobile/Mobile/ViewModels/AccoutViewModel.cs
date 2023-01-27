using Mobile.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Android.Content.ClipData;

namespace Mobile.ViewModels
{
    public class AccoutViewModel : BaseViewModel<String>
    {
        private string name;
        private string email;
        private string phone;

        public Command EditCommand { get; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public AccoutViewModel()
        {
            IsBusy = false;
            Title = "My Accout";
            Name = Preferences.Get("NAME", "");
            Email = Preferences.Get("EMAIL", "");
            Phone = Preferences.Get("PHONE", "");

            EditCommand = new Command(OnEditCommand);
        }

        private async void OnEditCommand(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(EditMyAccountPage)}");
        }

        public void OnAppearing()
        {
            Title = "My Accout";
            Name = Preferences.Get("NAME", "");
            Email = Preferences.Get("EMAIL", "");
            Phone = Preferences.Get("PHONE", "");
        }
    }
}
