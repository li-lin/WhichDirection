using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Core;
using WhichDirection.Domain.Entities;
using WhichDirection.Helper;

namespace WhichDirection.Controllers
{
    [StuIsLoginIn]
    public class ChoiceController : Controller
    {
        StudentManage s = new StudentManage();
        // GET: Choice
        public ActionResult Index()
        {
            var user = StuIsLoginIn.GetUser();
            ViewData["iscompleted"] = user.IsCompleted;
            return View();
        }

        public ActionResult ChangePwdShow()
        {
            return View();
        }

        public ActionResult ChangePwd(Student stu)
        {
            var user = StuIsLoginIn.GetUser();
            user.Pwd = stu.Pwd;
            s.AddStudent(user);
            return Content("<script>alert('修改密码成功');window.location.href='../Choice/Index';</script>");
        }
        public ActionResult SelectDirection()
        {
            return View();
        }
    }
}