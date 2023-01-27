using Mobile.Models;
using Mobile.Utils;
using Mobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class CartViewModel : BaseViewModel<Phone>
    {
        public ObservableCollection<Phone> Items { get; }
        public Command LoadItemsCommand { get; }

        public Command PurchaseCart { get; }

        public Command<Phone> ItemTapped { get; }

        public Command<Phone> ItemRemoved { get; }
        public Command<Phone> ItemAddCart { get; }

        public ICommand BuyCommand { get; }

        private string totalPrice;

        public string TotalPrice
        {
            get => totalPrice;
            set => SetProperty(ref totalPrice, value);
        }

        public CartViewModel()
        {
            Title = "User Cart";
            Items = new ObservableCollection<Phone>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            PurchaseCart = new Command(OnAddItem);

            ItemTapped = new Command<Phone>(OnItemSelected);

            ItemRemoved = new Command<Phone>(OnItemRemoved);

            ItemAddCart = new Command<Phone>(OnItemAdded);

            BuyCommand = new Command(OnBuy);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                int price = 0;
                foreach (var item in items)
                {
                    item.CartCount = CartUtils.GetPhoneCount(item);
                    if(item.CartCount > 0)
                    {
                        Items.Add(item);
                        price += item.Price;
                    }
                }
                TotalPrice = "Buy("+ price +"$)";
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
        }

        private async void OnAddItem(object obj)
        {
            string result = await Xamarin.Forms.Application.Current.MainPage.DisplayPromptAsync("Alert", "Please enter phone number");

            Phone newItem = new Phone()
            {
                Id = new Random().Next(),
                Name = result
            };

            await DataStore.AddItemAsync(newItem);

            OnAppearing();
        }

        private async void OnBuy(object obj)
        {
            //var popup = new BuyConfirmPopup();
            //await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
            //await Application.Current.MainPage.DisplayAlert("Buy?", "Total Price" + TotalPrice, "OK");
            await Shell.Current.GoToAsync($"{nameof(CheckoutPage)}");
        }

        async void OnItemSelected(Phone item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PhoneDetailPage)}?{nameof(PhoneDetailViewModel.ItemId)}={item.Id}");
        }

        async void OnItemRemoved(Phone item)
        {
            if (item == null)
                return;

            CartUtils.DeletePhoneCart(item);

            await Application.Current.MainPage.DisplayToastAsync(item.Name + " remove from cart successfully", 2000);

            OnAppearing();
        }

        async void OnItemAdded(Phone item)
        {
            if (item == null)
                return;

            await Task.Delay(10);
        }
    }
}