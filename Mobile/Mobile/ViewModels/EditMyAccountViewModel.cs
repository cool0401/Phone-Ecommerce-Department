using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class EditMyAccountViewModel : BaseViewModel<string>
    {
        private string name;
        private string phone;
        private string email;
        public int Id { get; set; }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public EditMyAccountViewModel()
        {
            Name = Preferences.Get("NAME", "");
            Phone = Preferences.Get("PHONE", "");
            Email = Preferences.Get("EMAIL", "");

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Preferences.Set("NAME", name);
            Preferences.Set("PHONE", phone);
            Preferences.Set("EMAIL", email);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private bool ValidateSave()
        {
            //("+1 (615) 243-5172"); // returns True

            // Validate if a string is a email 
            Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

            // Validate phone number
            //Regex validatePhoneNumberRegex = new Regex("^\\?[1-9][0-9]{7,14}$");

            return !String.IsNullOrWhiteSpace(name)
                //&& validatePhoneNumberRegex.IsMatch(phone)
                && validateEmailRegex.IsMatch(email);
        }
    }
}
