using Mobile.Models;
using Mobile.Utils;
using Mobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class CheckoutViewModel : BaseViewModel<Phone>
    {
        public ObservableCollection<Phone> Items { get; }

        public Command<Phone> ItemTapped { get; }

        public ICommand BuyCommand { get; }

        private string totalPrice;

        public string TotalPrice
        {
            get => totalPrice;
            set => SetProperty(ref totalPrice, value);
        }

        public CheckoutViewModel()
        {
            Title = "Check out";
            Items = new ObservableCollection<Phone>();

            ItemTapped = new Command<Phone>(OnItemSelected);

            BuyCommand = new Command(OnBuy);

            ExecuteLoadItemsCommand();
        }

        async void ExecuteLoadItemsCommand()
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
                    if (item.CartCount > 0)
                    {
                        Items.Add(item);
                        price += item.Price;
                    }
                }
                TotalPrice = "Total Price : " + price + "$";
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

        private async void OnBuy(object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Buy?", "Total Price" + TotalPrice, "OK");
        }

        async void OnItemSelected(Phone item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PhoneDetailPage)}?{nameof(PhoneDetailViewModel.ItemId)}={item.Id}");
        }
    }
}