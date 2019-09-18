using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SecondHandSuccess2.Models;
using System.Data.Entity;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SecondHandSuccess2.Controllers
{
    public class AdminController : Controller
    {

        Model model = new Model();

        public ActionResult AdminHome()
        {
            if (Session["User"] != null)
            {
                ViewBag.Modules = model.Modules;
                ViewBag.People = model.People;
                return View();
            }
            else
            {

                return RedirectToAction("LogIn", "Home");
            }

        }

        public ActionResult AddModule()
        {
            List<PERSON> people = new List<PERSON>();
            foreach (var user in model.People)
            {
                if (user.PersonType.Equals("Lecturer"))
                {
                    people.Add(user);
                }
            }

            ViewBag.lecturers = people;
            return View();
        }

        string lecturer;
        [HttpPost]
        public ActionResult addModule()
        {
            String moduleName = Request.Form["moduleName"];
            String moduleCode = Request.Form["moduleCode"];
            String personId = Request.Form["personId"];
            lecturer = personId;
            if(ModelState.IsValid)
            {
              
                Module module = new Module();
                module.moduleCode = moduleCode;
                module.moduleName = moduleName;
                module.moduleLecturer = personId;
                model.Modules.Add(module);
                model.SaveChanges();
            }

            return RedirectToAction("PromptLecturer", "Admin");
        }

        [HttpPost]
        public ActionResult add()
        {
            return RedirectToAction("AddModule", "Admin");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PromptLecturer()
        {

            String email = lecturer + "@mandela.ac.za";

            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = "personal.daniel.email@gmail.com";
                    var receiverEmail = new MailAddress(lecturer, "Receiver");
                    var message = new MailMessage();
                    var password = "winegums";
                    var sub = "Prescribe textbook";
                    var body ="Your module has been added, please prescribe a textbook";
                    using (var smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(senderEmail, password);

                        using (var mess = new MailMessage(senderEmail, password)
                        {
                            Subject = sub,
                            Body = body
                        })
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                        return RedirectToAction("Sent");
                    }
                   
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View(model);
        }
    }
}