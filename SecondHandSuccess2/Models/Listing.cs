namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Listing")]
    public partial class Listing
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string bookISBN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string personIDNumber { get; set; }

        [StringLength(50)]
        public string listingCondition { get; set; }

        [Column(TypeName = "date")]
        public DateTime? listingDate { get; set; }

        [StringLength(50)]
        public string listingPrice { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual PERSON PERSON { get; set; }
    }
}
