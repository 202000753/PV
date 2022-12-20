using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESTSBooks.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }

        [MaxLength(150)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(10, 2)"), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(0, 999)]
        public int Units { get; set; }

        [EnumDataType(typeof(BookCategory))]
        public BookCategory Category { get; set; }

        [ForeignKey("StoreId")]
        public Guid StoreId { get; set; }

        public BookStore? Store { get; set; }
    }
}
