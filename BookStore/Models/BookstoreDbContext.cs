using System;
using Microsoft.EntityFrameworkCore;
namespace BookStore.Models
{
	public class BookstoreDbContext:DbContext
    {
		public BookstoreDbContext(DbContextOptions<BookstoreDbContext>options):base(options)
		{

		}
		public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}

