using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.ViewModels;
using WhichDirection.Core;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Controllers
{
    public class HomeController : Controller
    {
        private UserManage um = new UserManage();
        // GET: Login
        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            User user = um.Login(model.LoginName, model.Password);
            if (user != null)
            {
                if (user.LoginName.StartsWith("JC"))
                {
                    Session["teaher"] = user.LoginName;
                    return RedirectToAction("Index", "Teacher");
                }
                else
                {
                    Session["student"] = user.LoginName;
                    return RedirectToAction("Index", "Choice");
                }
            }
            else
            {
                ModelState.AddModelError("LoginName", "用户名或密码错误");
                return RedirectToAction("Login", "Home");
            }
        }
    }
}