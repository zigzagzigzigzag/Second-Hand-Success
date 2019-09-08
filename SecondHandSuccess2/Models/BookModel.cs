namespace SecondHandSuccess2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookModel : DbContext
    {
        public BookModel()
            : base("name=BookModel")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.bookName)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.bookEdition)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.bookAuthor)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.bookPublisher)
                .IsUnicode(false);
        }
    }
}
