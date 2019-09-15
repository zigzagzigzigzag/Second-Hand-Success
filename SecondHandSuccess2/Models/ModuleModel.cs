namespace SecondHandSuccess2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModuleModel : DbContext
    {
        public ModuleModel()
            : base("name=ModuleModel1")
        {
        }

        public virtual DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>()
                .Property(e => e.moduleCode)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.moduleName)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.moduleLecturer)
                .IsFixedLength();
        }
    }
}
