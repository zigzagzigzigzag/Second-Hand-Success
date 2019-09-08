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
        [Key]
        [MaxLength(10)]
        public byte[] moduleCode { get; set; }

        [StringLength(50)]
        public string moduleName { get; set; }

        [StringLength(10)]
        public string moduleLecturer { get; set; }
    }
}
