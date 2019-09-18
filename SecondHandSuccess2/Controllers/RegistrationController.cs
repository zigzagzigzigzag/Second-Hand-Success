using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondHandSuccess2.Models;


namespace SecondHandSuccess2.Controllers
{
    public class RegistrationController : Controller
    {

        // GET: Registration
        [AllowAnonymous]
        public ActionResult Index()
        {
            Session.Contents.RemoveAll();
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(PERSON obj)

        {
            if (ModelState.IsValid)
            {
                SecondHandSuccessEntities1 db = new SecondHandSuccessEntities1();
                db.People.Add(obj);
                db.SaveChanges();
            }
            return RedirectToAction("LogIn", "Home");
        }

    }
}