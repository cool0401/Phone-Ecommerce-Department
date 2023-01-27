using Mobile.Models;
using System;
using Xamarin.Essentials;

namespace Mobile.Utils
{
    public static class CartUtils
    {
        public static bool IsContainPhone(Phone phone)
        {
            string[] items = Preferences.Get("INCART", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < items.Length; i++)
            {
                string[] data = items[i].Split(new char[] { ':' });
                if (data[0] == phone.Id.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetPhoneCount(Phone phone)
        {
            string[] items = Preferences.Get("INCART", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < items.Length; i++)
            {
                string[] data = items[i].Split(new char[] { ':' });
                if (data[0] == phone.Id.ToString())
                {
                    return Convert.ToInt32(data[1]);
                }
            }
            return 0;
        }

        public static bool AddPhoneCart(Phone phone)
        {
            try
            {
                string content = Preferences.Get("INCART", "");
                string newContent = "";
                string[] items = content.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                bool isCart = false;
                for (int i = 0; i < items.Length; i++)
                {
                    string[] data = items[i].Split(new char[] { ':' });
                    if (data[0] == phone.Id.ToString())
                    {
                        isCart = true;
                        newContent += ("," + data[0] + ":" + (Convert.ToInt32(data[1]) + 1));
                    }
                    else
                    {
                        newContent += (","+ items[i]);
                    }
                }
                if(!isCart)
                    newContent += ((items.Length > 0 ? "," : "") + phone.Id + ":" + 1);
                Preferences.Set("INCART", newContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemovePhoneCart(Phone phone)
        {
            try
            {
                string content = Preferences.Get("INCART", "");
                string newContent = "";
                string[] items = content.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < items.Length; i++)
                {
                    string[] data = items[i].Split(new char[] { ':' });
                    if (data[0] == phone.Id.ToString())
                    {
                        newContent += ("," + data[0] + ":" + (Convert.ToInt32(data[1]) - 1));
                    }
                    else
                    {
                        newContent += ("," + items[i]);
                    }
                }
                Preferences.Set("INCART", newContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeletePhoneCart(Phone phone)
        {
            try
            {
                string content = Preferences.Get("INCART", "");
                string newContent = "";
                string[] items = content.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < items.Length; i++)
                {
                    string[] data = items[i].Split(new char[] { ':' });
                    if (data[0] == phone.Id.ToString())
                    {
                    }
                    else
                    {
                        newContent += ("," + items[i]);
                    }
                }
                Preferences.Set("INCART", newContent);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
