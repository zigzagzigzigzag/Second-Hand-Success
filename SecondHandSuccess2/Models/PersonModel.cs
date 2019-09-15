namespace SecondHandSuccess2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonModel : DbContext
    {
        public PersonModel()
            : base("name=PersonModel1")
        {
        }

        public virtual DbSet<PERSON> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
