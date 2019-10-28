using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecondHandSuccess2.Models;


namespace SecondHandSuccess2.Controllers
{
    public class UserController : Controller
    {
        private SecondHandSuccessEntities2 db = new SecondHandSuccessEntities2();
        Model model = new Model();

        // GET: User
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = db.People.Find(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonIDNumber,PersonName,PersonSurname,PersonCellNumber,PersonEmail,PersonUserName,PersonPassword,PersonType,PersonRating")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(pERSON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERSON);
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = db.People.Find(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonIDNumber,PersonName,PersonSurname,PersonCellNumber,PersonEmail,PersonUserName,PersonPassword,PersonType,PersonRating")] PERSON pERSON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERSON);
        }


        //GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSON pERSON = db.People.Find(id);
            if (pERSON == null)
            {
                return HttpNotFound();
            }
            return View(pERSON);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PERSON pERSON = db.People.Find(id);
            db.People.Remove(pERSON);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult editModuleButton(string moduleEditing)
        {

            currentModuleName = moduleEditing;

            
            return RedirectToAction("PrescribeTextbook", "User"," ");
        }


        

        private static string currentModuleName;
        //public ActionResult PrescribeTextbook()
        //{
        //    if (Session["User"] != null)
        //    {
        //        PERSON currentUser = Session["User"] as PERSON;
        //        if (currentUser.PersonType.Equals("Lecturer"))
        //        {
        //            List<Module> modules = new List<Module>();
        //            foreach (var module in model.Modules)
        //            {
        //                modules.Add(module);
        //            }
        //            ViewBag.module = currentModuleName;
        //            ViewBag.modules = modules;
        //            ViewBag.books = model.BOOKs;
        //            return View();
        //        }
        //        else
        //        {
        //            return RedirectToAction("LogIn", "Home");
        //        }
        //    }
        //    else
        //    { 
        //        return RedirectToAction("LogIn", "Home");
        //    }

        //}
        public static string existence = " ";
      
        public ActionResult PrescribeTextbook()
        {

            ViewBag.existence = existence;
            if (existence.Length>2)
            {
                ViewBag.existence = existence;
            }
            if (Session["User"] != null)
            {
                PERSON currentUser = Session["User"] as PERSON;
                if (currentUser.PersonType.Equals("Lecturer"))
                {
                    List<Module> modules = new List<Module>();
                    foreach (var module in model.Modules)
                    {
                        modules.Add(module);
                    }
                    ViewBag.module = currentModuleName;
                    ViewBag.modules = modules;
                    ViewBag.books = model.BOOKs;
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

        //public ActionResult sendBag()
        //{
        //  existence = "ISBN exists already";
        //  return RedirectToAction("PrescribeTextbook", "User");
        //}

        public ActionResult confirmPrescribeTextbook()
        {
            
            string ISBN = Request.Form["bookISBN"];
            DateTime dateTime = DateTime.UtcNow;
            List< Module > modules = new List<Module>();
            PRESCRIBED prescribed = new PRESCRIBED();
            foreach (var module in model.Modules)
            {
                if (module.moduleName.Equals(currentModuleName))
                {
                   foreach(var book in model.BOOKs)
                    {
                        if (book.bookISBN.Equals(ISBN)){
                           
                            prescribed.bookISBN = book.bookISBN;
                            prescribed.moduleCode = module.moduleCode;
                            prescribed.prescribedDate = dateTime;
                        }
                    }
                }
            }
            if (ModelState.IsValid)
            {
                bool exists = false;
                foreach(PRESCRIBED existingPrescription in model.PRESCRIBEDs)
                {
                    if(prescribed.moduleCode.Equals(existingPrescription.moduleCode))
                    {
                        exists = true;
                       // existingPrescription.bookISBN = ISBN;
                        model.PRESCRIBEDs.Remove(existingPrescription);  
                        model.PRESCRIBEDs.Add(prescribed);
                    }
                }
                //if (exists)
                //{
                    
                //    return new HttpStatusCodeResult(204);
                //}
                //else
                //{
                  //  model.PRESCRIBEDs.Add(prescribed);
                    model.SaveChanges();
                    return RedirectToAction("LecturerHomePage", "Home");
                //}
                
            }
            else
            {
                return View(prescribed);
            }

           
        }

        [HttpPost]
        public ActionResult createNewBook(string pageDirect)
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
                BOOK book = new BOOK();

                if (ModelState.IsValid)
                {
                    book.bookISBN = ISBN;
                    book.bookName = name;
                    book.bookPublisher = publisher;
                    book.bookAuthor = author;
                    book.bookEdition = edition;
                    model.BOOKs.Add(book);
                    model.SaveChanges();
                    if (pageDirect == "Module")
                    {
                        return RedirectToAction("PrescribeTextbook", "User");
                    }
                    else
                    {
                        return RedirectToAction("AddListing", "Home");
                    }
                }
                else
                {
                    return View("PrescribeTextbook", book);
                }

            }
           
                return new HttpStatusCodeResult(204);
                
        }

    }
}
