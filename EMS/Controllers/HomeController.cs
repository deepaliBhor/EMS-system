using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS.Controllers
{
   
    public class HomeController : Controller
    {
        static List<ClsEmployee> Users = new List<ClsEmployee>();
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ClsEmployee clsEmployee)
        {
            if (ModelState.IsValid)
            {
                Users.Add(clsEmployee);
                return Content("<script type='text/javascript'>alert('Employee Registered Successfully!');window.location.href = 'Home/Register';</script>");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ClsEmployee clsEmployee)
        {
            foreach (var item in Users)
            {
                if ((item.UName == clsEmployee.UName) && (item.PWD == clsEmployee.PWD))
                {
                    TempData["UserName"] = clsEmployee.UName;
                    TempData["UserPwd"] = clsEmployee.PWD;
                    FormsAuthentication.SetAuthCookie(clsEmployee.UName, true);
                    return RedirectToAction("Profile");
                    
                }
                else
                {
                    return Content("<script type='text/javascript'>alert('Invalid User Name or Password! Please Try again');window.location.href = 'Login';</script>"); 
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Profile()
        {
            ViewBag.UserName = TempData["UserName"];
            ViewBag.UserPwd = TempData["UserPwd"];
            return View();
        }

    }
}