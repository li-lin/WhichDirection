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
    [AdminIsLoginIn]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCourseShow()
        {
            return View();
        }

        public ActionResult AddCourse(Course course)
        {
            using(WdDbContext dbContext = new WdDbContext())
            {
                dbContext.Courses.Add(course);
                return Content("<script>alert('添加成功');window.location.href='../Course/Index';</script>");
            }
        }
    }
}