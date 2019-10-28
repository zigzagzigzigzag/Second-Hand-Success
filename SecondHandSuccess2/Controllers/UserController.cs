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

            
            return RedirectToAction("PrescribeTextbook", "User");
        }


        

        private static string currentModuleName;
        public ActionResult PrescribeTextbook()
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
                        model.PRESCRIBEDs.Remove(existingPrescription);
                    }
                }
                model.PRESCRIBEDs.Add(prescribed);             
                model.SaveChanges();
            }

            return RedirectToAction("LecturerHomePage", "Home");
        }
    }
}
