namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOK")]
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            PRESCRIBEDs = new HashSet<PRESCRIBED>();
            Listings = new HashSet<Listing>();
        }

        [Key]
        [StringLength(13)]
        public string bookISBN { get; set; }

        [StringLength(70)]
        public string bookName { get; set; }

        [StringLength(50)]
        public string bookAuthor { get; set; }

        [StringLength(50)]
        public string bookPublisher { get; set; }

        [StringLength(50)]
        public string bookEdition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESCRIBED> PRESCRIBEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
