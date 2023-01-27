using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class NewContactViewModel : BaseViewModel<Mobile.Models.Contact>
    {
        private string name;
        private string email;
        private string phonen;
        private string address;

        public NewContactViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(phonen)
                && !String.IsNullOrWhiteSpace(address)
                && validateEmailRegex.IsMatch(email);
        }

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
        public string Phonen
        {
            get => phonen;
            set => SetProperty(ref phonen, value);
        }
        public string Address   
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Mobile.Models.Contact newItem = new Mobile.Models.Contact()
            {
                Id = new Random().Next(),
                Name = Name,
                Email = Email,
                Phonen = Phonen,
                Address = Address
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}