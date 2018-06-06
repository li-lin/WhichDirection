using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Core;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Controllers
{
    public class StudentController : Controller
    {
        WdDbContext dbContext = new WdDbContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Up(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string fileExtentian = file.FileName.Substring(file.FileName.LastIndexOf(".")).ToLower();
                if (fileExtentian == ".xls" || fileExtentian == ".xlsx")
                {
                    string newFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + fileExtentian;
                    string path = Server.MapPath("~/Content/" + newFileName);
                    file.SaveAs(path);
                    StudentManage stu = new StudentManage();
                    int b = stu.importStudentsFromExcel(path);
                    if (b == 1)
                    {
                        return Content("YES");
                    }
                    else if (b == 2)
                    {
                        return Content("chongfu");
                    }
                }
            }
            return Content("NO");
        }
    }
}