namespace SecondHandSuccess2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PerscribedModel : DbContext
    {
        public PerscribedModel()
            : base("name=PerscribedModel")
        {
        }

        public virtual DbSet<Perscribed> Perscribeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perscribed>()
                .Property(e => e.moduleCode)
                .IsFixedLength();

            modelBuilder.Entity<Perscribed>()
                .Property(e => e.perscribedDate)
                .IsFixedLength();
        }
    }
}
