using Mobile.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ContactDetailViewModel : BaseViewModel<Contact>
    {
        private int itemId;
        private string name;
        private string email;
        private string phonen;
        private string address;
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
                Email = item.Email;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
