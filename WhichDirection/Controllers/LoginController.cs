using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Controllers
{
    public class LoginController : Controller
    {
        WdDbContext dbContext = new WdDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        #region 判断教师或学生登录并返回对应页面
        public ActionResult LoginIn(User model)
        {
            if (model.LoginName.ToUpper().StartsWith("JC"))
            {
                //老师登录
                Teacher admin = dbContext.Teachers.SingleOrDefault(a => a.LoginName == model.LoginName.ToUpper() && a.Pwd == model.Pwd);
                if (admin == null)
                {
                    ModelState.AddModelError("LoginName", "用户名或密码错误");
                    return View();
                }
                else
                {
                    Session["admin"] = admin.LoginName;
                    return RedirectToAction("Index", "Student");
                }
            }
            else
            {
                //学生登录
                Student stu = dbContext.Students.SingleOrDefault(s => s.LoginName == model.LoginName && s.Pwd == model.Pwd);
                if (stu == null)
                {
                    ModelState.AddModelError("LoginName", "用户名或密码错误");
                    return View();
                }
                else
                {
                    Session["currStu"] = stu.LoginName;
                    return RedirectToAction("Index","Choice");
                }
            }
        }
        #endregion
    }
}