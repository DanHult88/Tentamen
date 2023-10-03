using Microsoft.EntityFrameworkCore;
using HemTenta.Models;


namespace HemTenta
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<BookClub> BookClubs { get; set; }
    }
}