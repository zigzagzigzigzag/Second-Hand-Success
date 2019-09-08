namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonIDNumber { get; set; }

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
    }
}
