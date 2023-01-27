using Mobile.Utils;
using SQLite;
using Xamarin.Forms;

namespace Mobile.Models
{
    [Table("Phone")]
    public class Phone
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Brand { get; set; }

        public int Price { get; set; }

        public string PriceSrc { get { return Price.ToString() + "$";  } }

        public string Image { get; set; }

        public ImageSource ImageSrc 
        {
            get { return FileUtils.Base64ToImage(Image); }
        }

        public int CartCount { get; set; }
    }
}