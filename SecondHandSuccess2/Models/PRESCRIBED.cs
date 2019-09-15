namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRESCRIBED")]
    public partial class PRESCRIBED
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string bookISBN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string moduleCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? prescribedDate { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual Module Module { get; set; }
    }
}
