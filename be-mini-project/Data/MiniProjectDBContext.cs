using Microsoft.EntityFrameworkCore;
using Mini_projeto_Book_Samsys.Models;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Mini_projeto_Book_Samsys.Data
{
    public class MiniProjectDBContext : DbContext
    {
        public MiniProjectDBContext(DbContextOptions<MiniProjectDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .Navigation(x => x.Authors)
                .AutoInclude();

            builder.Entity<Author>()
                .Navigation(x => x.Books);

            builder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books)
                .UsingEntity(j => j.ToTable("BookAuthors"));

            builder.Entity<Book>()
        .HasIndex(b => b.ISBN)
        .IsUnique();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}

