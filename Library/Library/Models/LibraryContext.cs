using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookList> BookLists { get; set; }

    public virtual DbSet<BookStatement> BookStatements { get; set; }

    public virtual DbSet<LibraryUser> LibraryUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=miachu.database.windows.net;Initial Catalog=Library;Persist Security Info=True;User ID=miachu;Password=sY.200415", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Chinese_Taiwan_Stroke_CI_AS");

        modelBuilder.Entity<BookList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookList__3214EC07281B654D");

            entity.ToTable("BookList");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<BookStatement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookStat__3214EC073371B407");

            entity.ToTable("BookStatement");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BorrowDate).HasColumnType("date");
            entity.Property(e => e.ReturnDate).HasColumnType("date");

            entity.HasOne(d => d.Book).WithMany(p => p.BookStatements)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookState__BookI__60A75C0F");

            entity.HasOne(d => d.Borrower).WithMany(p => p.BookStatements)
                .HasForeignKey(d => d.BorrowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookState__Borro__693CA210");
        });

        modelBuilder.Entity<LibraryUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LibraryU__3214EC07478DF465");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(254);
            entity.Property(e => e.Secret).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
