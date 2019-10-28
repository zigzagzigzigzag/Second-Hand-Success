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
            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult LogIn()
        {
            if (ViewBag.passError == null)
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
                PERSON currentUser = Session["User"] as PERSON;
                if (currentUser.PersonType.Equals("Lecturer"))
                {
                    ViewBag.Prescribed = model.PRESCRIBEDs;
                    ViewBag.modules = model.Modules;
                    ViewBag.User = Session["User"];
                    return View();
                }
                else
                {
                    return RedirectToAction("LogIn", "Home");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        public ActionResult EditListing()
        {
            if (Session["User"] != null)
            {
                string bookISBN = RouteData.Values["id"].ToString();
                string uId = ((PERSON)Session["User"]).PersonIDNumber;

                Listing curList = model.Listings.Find(bookISBN, uId);
                Session["currentListing"] = curList;


                List<String> conditions = new List<string> { "Very Bad", "Bad", "Average", "Good", "Very Good" };

                ViewBag.books = model.BOOKs;


                ViewData["conditions"] =
                    new SelectList(new[] { "Very Bad", "Bad", "Average", "Good", "Very Good" }
                    .Select(x => new { value = x, text = x }),
                    "value", "text", "Very Bad");

                return View(curList);
            }

            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        public ActionResult AddListing()
        {
            if (Session["User"] != null)
            {
                List<String> conditions = new List<string> { "Very Bad", "Bad", "Average", "Good", "Very Good" };
                ViewBag.books = model.BOOKs;
                ViewData["conditions"] =
                    new SelectList(new[] { "Very Bad", "Bad", "Average", "Good", "Very Good" }
                    .Select(x => new { value = x, text = x }),
                    "value", "text", "Very Bad");

                return View();
            }

            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        [HttpPost]
        public ActionResult confirmNewListing()
        {
            String bookISBN = Request.Form["bookISBN"];
            PERSON currentUser = Session["User"] as PERSON;
            String condition = " ";
            String price = " ";
            DateTime dateTime = DateTime.UtcNow;
            //String date = dateTime.ToString("yy-MM-dd");
            bool exists = false;
            //foreach (BOOK book in model.BOOKs)
            //{
            //    if (book.bookISBN.Equals(bookISBN))
            //    {
            //        exists = true;
            //    }
            //}
            foreach (Listing listing in model.Listings)
            {
                if (listing.personIDNumber.Equals(currentUser.PersonIDNumber))
                {
                    if (bookISBN.Equals(listing.bookISBN))
                    {
                        exists = true;
                    }
                }
            }
            if (!exists)
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
                return RedirectToAction("UserHomePage", "Home");
            }
            else
            {
                return new HttpStatusCodeResult(204);
            }


        }





        public ActionResult getView()
        {
            return View(model.BOOKs);
        }
        public ActionResult deleteListing()
        {

            string bookISBN = RouteData.Values["id"].ToString();
            string uId = ((PERSON)Session["User"]).PersonIDNumber;
            Listing toRemove = model.Listings.Find(bookISBN, uId);
            model.Listings.Remove(toRemove);
            model.SaveChanges();

            return RedirectToAction("UserHomePage", "Home");
        }
        public ActionResult editListingPage()
        {
            string condition = Request.Form["conditions"];
            var price = Request.Form["listingPrice"];

            Listing current = (Listing)Session["currentListing"];
            model.Listings.Find(current.bookISBN, current.personIDNumber).listingCondition = condition;
            model.Listings.Find(current.bookISBN, current.personIDNumber).listingPrice = price;
            model.SaveChanges();

            return RedirectToAction("UserHomePage", "Home");
        }


        public ActionResult HomePage()
        {
                if (Session["CurrentType"].ToString().Equals("Person"))
                {
                    return RedirectToAction("UserHomePage", "Home");
                }
                else if (Session["CurrentType"].ToString().Equals("Lecturer"))
                {
                    return RedirectToAction("LecturerHomePage", "Home");
                }
                else if (Session["CurrentType"].ToString().Equals("Admin"))
                {
                    return RedirectToAction("AdminHome", "Admin");
                }
            

            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult LogOn()
        {
            String uName = Request.Form["PersonUserName"];
            String uPassword = Request.Form["PersonPassword"];
            Boolean userFound = false;
            Session["uNameError"] = "";
            Session["passError"] = "";
            foreach (PERSON curP in model.People)
            {
                if (curP.PersonUserName == uName)
                {
                    userFound = true;
                    if (curP.PersonPassword == uPassword)
                    {
                        Session["User"] = curP;
                        personID = curP.PersonIDNumber;
                        if (curP.PersonType.Equals("Person"))
                        {
                            Session["CurrentType"] = "Person";
                            return RedirectToAction("UserHomePage", "Home");
                        }
                        else if (curP.PersonType.Equals("Lecturer"))
                        {
                            Session["CurrentType"] = "Lecturer";
                            return RedirectToAction("LecturerHomePage", "Home");
                        }
                        else if (curP.PersonType.Equals("Admin"))
                        {
                            Session["CurrentType"] = "Admin";
                            return RedirectToAction("AdminHome", "Admin");
                        }

                    }
                    else
                    {
                        Session["passError"] = "Incorrect Password";
                        return RedirectToAction("LogIn", "Home");
                    }
                }
            }
            if (!userFound)
            {
                Session["uNameError"] = "Username does not Exist";
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
        [HttpPost]
        public ActionResult filterSearch(string searchCriteria)
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("SearchResults", new { search = searchCriteria });
            }

            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        public ActionResult SearchResults(string search)
        {
            if (Session["User"] != null)
            {
                List<PERSON> foundPeople = new List<PERSON>();
                List<Listing> foundListings = new List<Listing>();
                List<PRESCRIBED> foundModules = new List<PRESCRIBED>();

                foreach (PERSON p in model.People)
                {
                    if (p.PersonName.Equals(search))
                    {
                        foundPeople.Add(p);
                    }
                }

                foreach (Listing l in model.Listings)
                {
                    if (l.BOOK.bookName.Equals(search))
                    {
                        foundListings.Add(l);
                    }
                }

                foreach (PRESCRIBED p in model.PRESCRIBEDs)
                {
                    if (p.moduleCode.Equals(search) || p.BOOK.bookName.Equals(search))
                    {
                        foundModules.Add(p);
                    }
                }

                ViewBag.searchText = search;
                ViewBag.people = foundPeople;
                ViewBag.listings = foundListings;
                ViewBag.modules = foundModules;

                return View();
            }

            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
    }
}