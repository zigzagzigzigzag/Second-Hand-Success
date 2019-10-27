using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SecondHandSuccess2.Models;
using System.Data.Entity;
using System.Net.Mail;

namespace SecondHandSuccess2.Controllers
{
    public class AdminController : Controller
    {

        Model model = new Model();

        public ActionResult AdminHome()
        {
            if (Session["User"] != null)
            {
                PERSON currentUser = Session["User"] as PERSON;
                if (currentUser.PersonType.Equals("Admin"))
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
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult AddModule()
        {                    
            if (Session["User"] != null)
            {
                PERSON currentUser = Session["User"] as PERSON;
                if (currentUser.PersonType.Equals("Admin"))
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

        [HttpPost]
        public ActionResult addModule()
        {
            if (Session["User"] != null)
            {
                    PERSON currentUser = Session["User"] as PERSON;
                    if (currentUser.PersonType.Equals("Admin"))
                    {
                    String moduleName = Request.Form["moduleName"];
                    String moduleCode = Request.Form["moduleCode"];
                    String lecturer = Request.Form["personID"];

                    bool exists = false;
                    foreach (Module module in model.Modules)
                    {
                        if (module.moduleCode.Equals(moduleCode) || module.moduleName.Equals(moduleName))
                        {
                            exists = true;
                        }
                    }

                    if (!exists)
                    {

                        if (ModelState.IsValid)
                        {

                            Module module = new Module();
                            module.moduleCode = moduleCode;
                            module.moduleName = moduleName;
                            module.moduleLecturer = lecturer;


                            model.Modules.Add(module);
                            model.SaveChanges();
                            foreach (PERSON person in model.People)
                            {
                                if (person.PersonIDNumber.Equals(lecturer))
                                {
                                    string bodyText = "Dear " + person.PersonName + ",\r\n Please prescribe a textbook for " + moduleName;
                                    sendEmail(person.PersonEmail, "Prescibe Textbook", bodyText);
                                }
                            }

                        }
                        return RedirectToAction("AdminHome", "Admin");
                    }
                    return new HttpStatusCodeResult(204);

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

        [HttpPost]
        public ActionResult add()
        {
            return RedirectToAction("AddModule", "Admin");
        }

        public ActionResult getLecturers()
        {
            List<PERSON> people = new List<PERSON>();         
            foreach (var user in model.People)
            {
                //people.Add(user);
                if (user.PersonType.Equals("Lecturer"))
                {
                    people.Add(user);
                }
            }

            ViewBag.lecturers = people;
            return View();
        }

        public ActionResult startYearPrompt()
        {
            foreach (PERSON person in model.People)
            {
                if (person.PersonType.Equals("Lecturer"))
                {
                    string bodyText = "Dear " + person.PersonName + ",\r\n Please update your modules' textbooks ";
                    string subject = "Update Modules' textbooks";
                    sendEmail(person.PersonEmail,subject,bodyText);
                }
            }
            return RedirectToAction("AdminHome", "Admin");
        }

        private void sendEmail(string lecturer,string subjectInput,string bodyText)
        {
            // Remove next line for final test       
            //lecturer = "s216458366@mandela.ac.za";

            try
            {

                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("itsnotabugitsafeature123@gmail.com", "Second Hand Success");
                    var receiverEmail = new MailAddress(lecturer, "Reciever");
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Timeout = 10000,
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, "Project123")

                    };

                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subjectInput,
                        Body = bodyText
                    })
                    {
                        smtp.Send(mess);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
        }


        public void radioMethod(string searchGroup)
        {
            string temp = searchGroup;
        }

    }
}