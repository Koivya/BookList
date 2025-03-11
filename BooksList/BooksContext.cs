using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BooksList;

public partial class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\k0val\\source\\repos\\BooksList\\BooksList\\books.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("book");

            entity.HasIndex(e => e.BookId, "IX_book_book_id").IsUnique();

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.Genre).HasColumnName("genre");
            entity.Property(e => e.Publisher).HasColumnName("publisher");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.YearOfPublication).HasColumnName("year_of_publication");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
