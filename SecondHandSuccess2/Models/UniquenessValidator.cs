using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SecondHandSuccess2.Models
{
    public class UniquenessValidator : ValidationAttribute
    {
        private Model model = new Model();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //string ISBN = (string)value;
            var book = validationContext.ObjectInstance as BOOK;
            string ISBN = book.bookISBN;
            foreach (BOOK books in model.BOOKs)
            {
                if (ISBN.Equals(books.bookISBN))
                {
                    return new ValidationResult("ISBN already exists");
                }
            }

            return ValidationResult.Success;
        }

    }
}