namespace SecondHandSuccess2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Models")
        {
        }

        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<PERSON> People { get; set; }
        public virtual DbSet<PRESCRIBED> PRESCRIBEDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOOK>()
                .Property(e => e.bookISBN)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.bookName)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.bookAuthor)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.bookPublisher)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.bookEdition)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.PRESCRIBEDs)
                .WithRequired(e => e.BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.Listings)
                .WithRequired(e => e.BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.bookISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.personIDNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.listingCondition)
                .IsUnicode(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.listingPrice)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.moduleCode)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.moduleName)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.moduleLecturer)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.PRESCRIBEDs)
                .WithRequired(e => e.Module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonIDNumber)
                .IsFixedLength().IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonSurname)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonCellNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonEmail)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonUserName)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonPassword)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonType)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .Property(e => e.PersonRating)
                .IsUnicode(false);

            modelBuilder.Entity<PERSON>()
                .HasMany(e => e.Listings)
                .WithRequired(e => e.PERSON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRESCRIBED>()
                .Property(e => e.bookISBN)
                .IsUnicode(false);

            modelBuilder.Entity<PRESCRIBED>()
                .Property(e => e.moduleCode)
                .IsUnicode(false);
        }
    }
}
