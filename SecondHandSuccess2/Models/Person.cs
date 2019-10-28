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
        [Display(Name = "ID Number")]
        [StringLength(13,MinimumLength =13,ErrorMessage =" ID Number must be 13 Characters")]
        [Required(ErrorMessage = "ID Number required")]
        public string PersonIDNumber { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "First Name required")]
        public string PersonName { get; set; }

        [Display(Name = "Surname")]
        [StringLength(50)]
        [Required(ErrorMessage = "Surname required")]
        public string PersonSurname { get; set; }

        [Display(Name = "Cell number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Cell Number must be 10 Digits")]
        [Required(ErrorMessage = "Cell Number required")]
        public string PersonCellNumber { get; set; }

        [Display(Name = "Email address")]
        [StringLength(50)]
        [Required(ErrorMessage = "Email Address required")]
        public string PersonEmail { get; set; }

        [Display(Name = "User Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "User Name required")]
        public string PersonUserName { get; set; }

        [Display(Name = "Password")]
        [StringLength(50)]
        [Required(ErrorMessage = "Password required")]
        public string PersonPassword { get; set; }

        [Display(Name = "What type of user are you?")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Select a User Type")]
        public string PersonType { get; set; }

        [StringLength(50)]
        public string PersonRating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Listing> Listings { get; set; }
    }
}