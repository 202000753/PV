using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ESTSBooks.Models;

namespace ESTSBooks.Data
{
    public class ApplicationDbContext : IdentityDbContext<BookUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ESTSBooks.Models.Book> Book { get; set; }
        public DbSet<ESTSBooks.Models.BookStore> BookStore { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var lisbonStore = new BookStore
            {
                BookStoreId = Guid.NewGuid(),
                Location = "Lisbon"
            };

            var portoStore = new BookStore
            {
                BookStoreId = Guid.NewGuid(),
                Location = "Porto"
            };


            var book1 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Book #1",
                Category = BookCategory.Action,
                Price = 10.5m,
                Units = 50,
                StoreId = lisbonStore.BookStoreId
            };

            var book2 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Book #2",
                Category = BookCategory.Triller,
                Price = 9.95m,
                Units = 150,
                StoreId = lisbonStore.BookStoreId
            };

            var book3 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Book #3",
                Category = BookCategory.Comedy,
                Price = 16.95m,
                Units = 20,
                StoreId = lisbonStore.BookStoreId
            };

            var book4 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Book #4",
                Category = BookCategory.Action,
                Price = 6.95m,
                Units = 200,
                StoreId = portoStore.BookStoreId
            };

            var book5 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Book #5",
                Category = BookCategory.Romance,
                Price = 29.99m,
                Units = 10,
                StoreId = portoStore.BookStoreId
            };

            modelBuilder.Entity<BookStore>().HasData(lisbonStore, portoStore);
            modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4, book5);
        }
    }
}