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
        [StringLength(13,MinimumLength =13,ErrorMessage = "ISBN length must be 13 characters")]
        [Required(ErrorMessage ="ISBN required")]
        [UniquenessValidator]

        public string bookISBN { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "Name required")]
        public string bookName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Author required")]
        public string bookAuthor { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Publisher required")]
        public string bookPublisher { get; set; }

        [StringLength(50)]
        [Range(1,50,ErrorMessage = "Must be greater than 0")]
        [Required(ErrorMessage = "Edition required")]

        public string bookEdition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRESCRIBED> PRESCRIBEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Listing> Listings { get; set; }
    }



    //public class CustomValidator:ValidationAttribute
    //{
    //    private Model model = new Model();

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //       //string ISBN = (string)value;
    //        var book = validationContext.ObjectInstance as BOOK;
    //        string ISBN = book.bookISBN;
    //       foreach (BOOK books in model.BOOKs)
    //        {
    //            if (ISBN.Equals(books.bookISBN))
    //            {
    //                return new ValidationResult("ISBN already exists");
    //            }
    //        }
            
    //        return ValidationResult.Success;
    //    }
    //}
}

