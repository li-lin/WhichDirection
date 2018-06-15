using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;
using WhichDirection.Helper;

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
                    return Content("<script>alert('工号或者密码错误！');window.parent.location.href='/Login/Login'</script>");
                }
                else
                {
                    TeIsLoginIn.userName = admin.LoginName;
                    return RedirectToAction("Index", "Student");
                }
            }
            else if(model.LoginName=="admin")
            {
                //管理员登录
                User admin = dbContext.Users.SingleOrDefault(s => s.LoginName == model.LoginName && s.Pwd == model.Pwd);
                if (admin == null)
                {
                    return Content("<script>alert('错误！');window.parent.location.href='/Login/Login'</script>");
                }
                else
                {
                    AdminIsLoginIn.userName = admin.LoginName;
                    return RedirectToAction("Index", "AdminHome");
                }
            }
            else
            {
                //学生登录
                Student stu = dbContext.Students.SingleOrDefault(s => s.LoginName == model.LoginName && s.Pwd == model.Pwd);
                if (stu == null)
                {
                    return Content("<script>alert('学号或者密码错误！');window.parent.location.href='/Login/Login'</script>");
                }
                else
                {
                    StuIsLoginIn.userName = stu.LoginName;
                    return RedirectToAction("Index", "Choice");
                }
            }
        }
        #endregion
    }
}