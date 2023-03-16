using LibraryManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Data
{
    public class LibraryManagementDbContext : DbContext
    {
        public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Book).WithMany(ba => ba.Book_Authors).HasForeignKey(b => b.BookId).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Author).WithMany(ba => ba.Book_Author).HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.Restrict); ;
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Book_Author> Book_Author { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
    }
}
