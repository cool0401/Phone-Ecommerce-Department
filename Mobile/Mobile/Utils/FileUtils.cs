using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Mobile.Utils
{
    public class FileUtils
    {
        //public static BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        //{
        //    BitmapImage img = new BitmapImage();
        //    using (MemoryStream memStream = new MemoryStream(imageByteArray))
        //    {
        //        img.BeginInit();
        //        img.CacheOption = BitmapCacheOption.OnLoad;
        //        img.StreamSource = memStream;
        //        img.EndInit();
        //        img.Freeze();
        //    }
        //    return img;
        //}

        public static ImageSource Base64ToImage(string base64String)
        {
            if (String.IsNullOrEmpty(base64String)) base64String = "";
            byte[] imageBytes = Convert.FromBase64String(base64String);
            return ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
    }
}
