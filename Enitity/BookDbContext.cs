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
        
        modelBuilder.Entity<BookModel>(b => 
            b.Property(book => book.name)
                .IsRequired()
                .HasMaxLength(20)
            );
        modelBuilder.Entity<AddBookModel>(b => b.HasNoKey().Property(book => book.name).IsRequired().HasMaxLength(20));


        base.OnModelCreating(modelBuilder);
    }

}
