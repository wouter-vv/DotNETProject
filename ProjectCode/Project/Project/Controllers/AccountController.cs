using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Controllers
{

    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        /**
         * Login View
         **/
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                return View();
            }
        }

        /**
         * Log the user in or return error
         **/
        [HttpPost]
        public ActionResult Login(userlogin usr)
        {
            if (ModelState.IsValid)
            {
                if (user.login(usr.email, usr.password))
                {
                    ModelState.AddModelError("Login", "Login gegevens zijn verkeerd");
                    return View(usr);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(usr.email, true);
                    return Redirect("~/Home/Index");
                }
            }

            return View(usr);
        }

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                return Redirect("~/Pages/Register.aspx");
            }
        }

        /**
         * Log the user out 
         **/
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home", null);
        }

        /**
         * Return the account view 
         **/
        [Authorize]
        public ActionResult Account()
        {
            user usr = user.getUser();
            ViewBag.User = usr;
            return View(usr);
        }

        /**
         * Submit the changes to the account 
         **/
        [Authorize]
        [HttpPost]
        public ActionResult Account(user usr)
        {
            if (usr.last_name == "")
            {
                usr.last_name = user.getUser().last_name;
            }
            if (usr.first_name == "")
            {
                usr.first_name = user.getUser().first_name;
            }

            user.updateProfile(usr);
            ViewBag.User = user.getUser();
            return RedirectToAction("Account", "Account");
        }


    }
    
}