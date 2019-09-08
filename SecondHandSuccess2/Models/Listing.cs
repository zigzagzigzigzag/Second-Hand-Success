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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long bookISBN { get; set; }

        public long? personIDNumber { get; set; }

        [StringLength(50)]
        public string listingCondition { get; set; }

        [StringLength(50)]
        public string listingDate { get; set; }

        public int? listingPrice { get; set; }
    }
}
