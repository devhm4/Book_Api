using System;
using books.Model;
using Microsoft.EntityFrameworkCore;

namespace books.Enitity;

public class BookDbContext : DbContext
{

    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    public DbSet<BookModel> Books { get; set; }
    public DbSet<CategoryModel> categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the many-to-many relationship and join table
        modelBuilder.Entity<BookModel>()
            .HasMany(b => b.Categories)
            .WithMany(c => c.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookCategory",
                j => j.HasOne<CategoryModel>().WithMany().HasForeignKey("CategoryId"),
                j => j.HasOne<BookModel>().WithMany().HasForeignKey("BookModelId")
            );

        base.OnModelCreating(modelBuilder);
    }

}
