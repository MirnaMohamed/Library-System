using Bogus;
using Castle.Core.Resource;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var authorModel = modelBuilder.Entity<Author>();
            authorModel.HasKey(a => a.Id);
            authorModel.HasMany(x => x.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            authorModel.HasIndex(a => a.Email).IsUnique();
            authorModel.HasIndex(a => a.FullName).IsUnique();

        }
    }
}
