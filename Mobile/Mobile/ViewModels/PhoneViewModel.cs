using Mobile.Models;
using Mobile.Utils;
using Mobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class PhoneViewModel : BaseViewModel<Phone>
    {
        private Phone _selectedItem;

        public ObservableCollection<Phone> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Phone> ItemTapped { get; }

        public Command<Phone> ItemAddCart { get; }

        public PhoneViewModel()
        {
            Title = "Phone";
            Items = new ObservableCollection<Phone>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Phone>(OnItemSelected);

            ItemAddCart = new Command<Phone>(OnItemCarted);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Phone SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(NewPhonePage));
            string result = await Xamarin.Forms.Application.Current.MainPage.DisplayPromptAsync("Alert", "Please enter phone number");

            Phone newItem = new Phone()
            {
                Id = new System.Random().Next(),
                Name = result
            };

            await DataStore.AddItemAsync(newItem);

            OnAppearing();
        }

        async void OnItemSelected(Phone item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PhoneDetailPage)}?{nameof(PhoneDetailViewModel.ItemId)}={item.Id}");
        }

        async void OnItemCarted(Phone item)
        {
            if (item == null)
                return;

            CartUtils.AddPhoneCart(item);

            await Application.Current.MainPage.DisplayToastAsync(item.Name + " add to cart successfully", 2000);
        }
    }
}