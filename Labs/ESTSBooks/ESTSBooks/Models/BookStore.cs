using System.ComponentModel.DataAnnotations;

namespace ESTSBooks.Models
{
    public class BookStore
    {
        [Key]
        public Guid BookStoreId { get; set; }
        public string Location { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
