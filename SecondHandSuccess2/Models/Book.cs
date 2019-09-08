namespace SecondHandSuccess2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long bookISBN { get; set; }

        [StringLength(50)]
        public string bookName { get; set; }

        [StringLength(50)]
        public string bookEdition { get; set; }

        [StringLength(50)]
        public string bookAuthor { get; set; }

        [StringLength(50)]
        public string bookPublisher { get; set; }
    }
}
