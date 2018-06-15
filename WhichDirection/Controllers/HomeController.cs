using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Helper;

namespace WhichDirection.Controllers
{
    [AdminIsLoginIn]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            AdminIsLoginIn.userName = null;
            StuIsLoginIn.userName = null;
            TeIsLoginIn.userName = null;
            return Content("<script>alert('注销成功');window.parent.location.href='/Login/Login'</script>");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}