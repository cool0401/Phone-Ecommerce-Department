using System;
using System.Diagnostics;
using Mobile.Models;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PhoneDetailViewModel : BaseViewModel<Phone>
    {
        private int itemId;
        private string name;
        private string brand;
        private string price;
        private ImageSource image;
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Brand
        {
            get => brand;
            set => SetProperty(ref brand, value);
        }
        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public ImageSource Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Price =  "$" + item.Price.ToString();
                Brand = item.Brand;
                Image = item.ImageSrc;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
