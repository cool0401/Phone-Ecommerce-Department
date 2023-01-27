using SQLite;

namespace Mobile.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phonen { get; set; }
        public string Address { get; set; }
    }
}