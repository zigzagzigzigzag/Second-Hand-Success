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
using System.Data.SqlClient;

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

        [HttpPost]
        public ActionResult addModule()
        {
            String moduleName = Request.Form["moduleName"];
            String moduleCode = Request.Form["moduleCode"];
            String personId = Request.Form["personId"]; 
            if(ModelState.IsValid)
            {
              
                Module module = new Module();
                module.moduleCode = moduleCode;
                module.moduleName = moduleName;
                module.moduleLecturer = personId;
                model.Modules.Add(module);
                model.SaveChanges();
            }
            

            //    bool exists = false;
            //    foreach (PERSON person in model.People)
            //    {
            //        if (person.PersonIDNumber.Equals(personId))
            //        {
            //            exists = true;
            //        }
            //    }
            //    if (!exists)
            //    {

            //        model.Database.ExecuteSqlCommand("INSERT INTO Module (moduleCode,moduleName,moduleLecturer) VALUES(" + moduleName + "," + moduleCode + "," + personId + ")");
            //    }

            //SqlConnection con = new SqlConnection(@"connectionString=data source = SecondHandSuccess.mssql.somee.com; password = b55r7324n8; initial catalog = SecondHandSuccess; user id = itsnotabug123_SQLLogin_1; MultipleActiveResultSets = True; App = EntityFramework providerName= System.Data.SqlClient");
            //SqlCommand cmd = new SqlCommand("INSERT INTO Module (moduleCode,moduleName,moduleLecturer) VALUES(" + moduleName + "," + moduleCode + "," + personId + ")", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@moduleCode", moduleCode);
            //cmd.Parameters.AddWithValue("@moduleName", moduleName);
            //cmd.Parameters.AddWithValue("@personIDNumber", textBox3.Text);
            //cmd.Parameters.AddWithValue("@address", textBox4.Text);
            //con.Open();

            return RedirectToAction("AdminHome", "Admin");
        }

        [HttpPost]
        public ActionResult add()
        {
            return RedirectToAction("AddModule", "Admin");
        }

    }
}