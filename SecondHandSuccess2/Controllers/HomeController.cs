using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondHandSuccess2.Models;

namespace SecondHandSuccess2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session.Contents.RemoveAll();
            return RedirectToAction("LogIn","Home");
        }

        public ActionResult LogIn()
        {
            if(ViewBag.passError == null)
            ViewBag.passError = "";

            return View();
        }

        Model model = new Model();
        private static String personID;

        public ActionResult UserHomePage()
        {
            if (Session["User"] != null)
            {
                ViewBag.Listings = model.Listings;
                ViewBag.User = Session["User"];
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        public ActionResult LecturerHomePage()
        {
            if (Session["User"] != null)
            {
                ViewBag.Prescribed = model.PRESCRIBEDs;
                ViewBag.User = Session["User"];
                return View();
            }
            else 
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

       public ActionResult EditListing()
       {      
            return View();
       }

        public ActionResult AddListing()
        {

            List<String> conditions = new List<string> { "Very Bad", "Bad", "Average", "Good", "Very Good" };

            ViewBag.books = model.BOOKs;


            ViewData["conditions"] =
                new SelectList(new[] { "Very Bad", "Bad", "Average", "Good", "Very Good" }
                .Select(x => new { value = x, text = x }),
                "value", "text", "Very Bad");

            return View();
        }

        [HttpPost]
        public ActionResult confirmNewListing()
        {
            String bookISBN = Request.Form["bookISBN"];

            String condition = " ";
            String price = " ";
            DateTime dateTime = DateTime.UtcNow;
            //String date = dateTime.ToString("yy-MM-dd");
            bool exists = false;
            foreach (BOOK book in model.BOOKs)
            {
                if (book.bookISBN.Equals(bookISBN))
                {
                    exists = true;
                }
            }

            if (exists)
            {
                condition = Request.Form["conditions"];
                price = Request.Form["listingPrice"];
                if (ModelState.IsValid)
                {

                    Listing listing = new Listing();
                    listing.bookISBN = bookISBN;
                    listing.listingCondition = condition;
                    listing.listingDate = dateTime;
                    listing.listingPrice = price;
                    listing.personIDNumber = personID;
                    model.Listings.Add(listing);
                    model.SaveChanges();
                }
            }

            return RedirectToAction("UserHomePage", "Home");
        }


        [HttpPost]
        public ActionResult createNewBook()
        {

            String ISBN = Request.Form["book.bookISBN"];
            String name = Request.Form["book.bookName"];
            String publisher = Request.Form["book.bookPublisher"];
            String author = Request.Form["book.bookAuthor"];
            String edition = Request.Form["book.bookEdition"];
            
            bool exists = false;
            foreach (BOOK book in model.BOOKs)
            {
                if (book.bookISBN.Equals(ISBN))
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                if (ModelState.IsValid)
                {

                    BOOK book = new BOOK();
                    book.bookISBN = ISBN;
                    book.bookName = name;
                    book.bookPublisher = publisher;
                    book.bookAuthor = author;
                    book.bookEdition = edition;
                    model.BOOKs.Add(book);
                    model.SaveChanges();
                }
                
            }

            return RedirectToAction("AddListing", "Home");


        }
    

    public ActionResult getView()
    {
        return View(model.BOOKs);
    }


    [HttpPost]
        public ActionResult LogOn()
        {
            String uName = Request.Form["PersonUserName"];
            String uPassword = Request.Form["PersonPassword"];
            foreach (PERSON curP in model.People) {
                if (curP.PersonUserName == uName)
            { if (curP.PersonPassword == uPassword)
                    {
                        Session["User"] = curP;
                        personID = curP.PersonIDNumber;
                        if (curP.PersonType.Equals("Person"))
                        {
                            return RedirectToAction("UserHomePage", "Home");
                        }
                        else if (curP.PersonType.Equals("Lecturer"))
                        {
                            return RedirectToAction("LecturerHomePage", "Home");
                        }
                        else if (curP.PersonType.Equals("Admin"))
                        {
                            return RedirectToAction("AdminHome", "Admin");
                        }

                    }
                    else {
                        ViewBag.passError = "Incorrect";
                        return RedirectToAction("LogIn", "Home");
                    }
                }
            }
            return RedirectToAction("LogIn", "Home");
        }

        [HttpPost]
        public Action UpdateListing()
        {
            ViewBag.Updated = "failed";
            String tName = Request.Form["tName"];
            String tPrice = Request.Form["tPrice"];
            foreach (Listing curL in model.Listings)
            {
                if (curL.BOOK.bookName == tName)
                {
                    curL.listingPrice = tPrice;
                    ViewBag.Updated = "Successful";
                    //RedirectToAction("UserHomePage", "Home");
                    break;
                }
            }
            return null;
        }



    }
}