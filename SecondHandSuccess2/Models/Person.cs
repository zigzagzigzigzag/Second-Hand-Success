namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSON")]
    public partial class PERSON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSON()
        {
            Listings = new HashSet<Listing>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(13)]
        public string PersonIDNumber { get; set; }

        [StringLength(50)]
        public string PersonName { get; set; }

        [StringLength(50)]
        public string PersonSurname { get; set; }

        [StringLength(10)]
        public string PersonCellNumber { get; set; }

        [StringLength(50)]
        public string PersonEmail { get; set; }

        [StringLength(50)]
        public string PersonUserName { get; set; }

        [StringLength(50)]
        public string PersonPassword { get; set; }

        [StringLength(50)]
        public string PersonType { get; set; }

        [StringLength(50)]
        public string PersonRating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
