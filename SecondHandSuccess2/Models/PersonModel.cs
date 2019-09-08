namespace SecondHandSuccess2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonModel : DbContext
    {
        public PersonModel()
            : base("name=PersonModel")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonSurname)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonCellNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonUserName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonType)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonRating)
                .IsUnicode(false);
        }
    }
}
