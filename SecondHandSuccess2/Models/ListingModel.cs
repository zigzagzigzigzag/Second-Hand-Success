namespace SecondHandSuccess2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ListingModel : DbContext
    {
        public ListingModel()
            : base("name=ListingModel1")
        {
        }

        public virtual DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listing>()
                .Property(e => e.listingCondition)
                .IsUnicode(false);

            modelBuilder.Entity<Listing>()
                .Property(e => e.listingDate)
                /*.IsUnicode(false)*/;
        }
    }
}
