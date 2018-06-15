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
    [AdminIsLoginIn]
    public class TeacherController : Controller
    {
        TeacherManage te = new TeacherManage();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTeaMsg()
        {
            ViewBag.temsg = te.GetTeachers();
            return View();
        }

        public ActionResult AddTeaMsgView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeaMsg(Teacher teacher)
        {
            teacher.IsAdmin = false;
            teacher.IsTeacher = true;
            teacher.Pwd = "123456";
            if (te.AddTeacher(teacher))
            {
                return Content("<script>alert('添加信息成功');window.location.href='../Teacher/Index';</script>");
            }
            else
            {
                return Content("<script>alert('添加信息失败');window.location.href='../Teacher/Index';</script>");
            }
        }
    }
}