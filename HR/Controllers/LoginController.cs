using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Fixed username and password
            string fixedUsername = "kismat";
            string fixedPassword = "1234";

            if (username == fixedUsername && password == fixedPassword)
            {
                // Save session to remember user is logged in
                Session["username"] = username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }
        }
    }
}