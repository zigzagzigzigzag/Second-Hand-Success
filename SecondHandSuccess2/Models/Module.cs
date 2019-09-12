namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Module")]
    public partial class Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Module()
        {
            PRESCRIBEDs = new HashSet<PRESCRIBED>();
        }

        [Key]
        [StringLength(50)]
        public string moduleCode { get; set; }

        [StringLength(50)]
        public string moduleName { get; set; }

        [StringLength(30)]
        public string moduleLecturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESCRIBED> PRESCRIBEDs { get; set; }
    }
}
