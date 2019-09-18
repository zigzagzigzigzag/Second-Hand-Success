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
                return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        Model model = new Model();
        private static String personID ;

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
            //List<BOOK> books = new List<BOOK>();
            //foreach (var book in model.BOOKs)
            //{
            //    books.Add(book);
            //}
            ViewBag.books = model.BOOKs;
          

            ViewData["conditions"] =
                new SelectList(new[] { "Very Bad", "Bad", "Average", "Good", "Very Good" }
                .Select(x => new { value = x, text = x }),
                "value", "text", "Very Bad");

            return View();
        }
        [HttpPost]
        public ActionResult addListing()
        {
            return RedirectToAction("AddListing", "Home");
        }

        [HttpPost]
        public ActionResult LogOn()
        {
            String uName = Request.Form["PersonUserName"];
            String uPassword = Request.Form["PersonPassword"];
            foreach (PERSON curP in model.People) {
                if (curP.PersonUserName == uName)
            { if (curP.PersonPassword == uPassword) {
                        Session["User"] = curP;
                        personID = curP.PersonIDNumber;
                        if (curP.PersonType.Equals("Person"))
                        {
                            return RedirectToAction("UserHomePage", "Home");
                        }else if (curP.PersonType.Equals("Lecturer"))
                        {
                            return RedirectToAction("LecturerHomePage", "Home");
                        }
                        else if (curP.PersonType.Equals("Admin"))
                        {
                            return RedirectToAction("AdminHome", "Admin");
                        }
                        
                    }
                    
                }
            }
            return null;
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


        [HttpPost]
        public ActionResult confirmNewListing()
        {
            String bookName = " ";
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
                condition = Request.Form["listingCondition"];
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
            String bookISBN = "9781119473923";
            String bookName = "Web Code and development";
            String bookPublisher = "John Wiley &S ons";
            String bookAuthor = "Paul McFredries";
            String bookEdition = "2";
            if(Request.Form["bookISBN"] != null)
               bookISBN = Request.Form["bookISBN"];
            if (Request.Form["bookName"] != null)
                bookName = Request.Form["bookName"];
            if (Request.Form["bookPublisher"] != null)
                bookPublisher = Request.Form["bookPublisher"];
            if (Request.Form["bookAuthor"] != null)
                bookAuthor = Request.Form["bookAuthor"];
            if (Request.Form["bookEdition"] != null)
                bookEdition = Request.Form["bookEdition"];
         
            if (ModelState.IsValid)
            {

                BOOK book = new BOOK();
                book.bookISBN = bookISBN;
                book.bookAuthor = bookAuthor;
                book.bookEdition = bookEdition;
                book.bookPublisher = bookPublisher;
                book.bookName = bookName;
                model.BOOKs.Add(book);
                model.SaveChanges();
            }


            return View();
        }
    }

}
    
