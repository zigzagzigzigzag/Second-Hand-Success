namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Perscribed")]
    public partial class Perscribed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long bookISBN { get; set; }

        [StringLength(50)]
        public string moduleCode { get; set; }

        [StringLength(10)]
        public string perscribedDate { get; set; }
    }
}
