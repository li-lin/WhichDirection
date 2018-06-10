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
        StudentManage stu = new StudentManage();
        WdDbContext dbContext = new WdDbContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 上传EXCEL
        /// </summary>
        /// <returns></returns>
        public ActionResult UpExcel()
        {
            return View();
        }
        #region 上传文件
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
        #endregion
        #region 查询学生信息
        public ActionResult ShowStuMsg()
        {
            return View();
        }

        public ActionResult GetStuMsg(string msg)
        {
            ViewBag.stumsg = stu.GetStuInfo(msg);
            if (ViewBag.stumsg != null)
            {
                return View();
            }
            else
            {
                return Content("信息有误");
            }
        }
        #endregion
        #region 添加学生信息
        public ActionResult AddStuMsg()
        {
            return View();
        }
        
        public ActionResult AddStuMsg(Student stud)
        {
            Student student = new Student();
            student.Name = stud.Name;
            student.LoginName = stud.LoginName;
            student.Major = stud.Major;
            student.IsCompleted = false;
            student.IsTeacher = false;
            student.Pwd = "123456";
            if (stu.AddStudent(student))
            {
                return Content("<script>alert('添加信息成功');window.location.href='../Student/Index';</script>");
            }
            else
            {
                return Content("<script>alert('添加信息失败');window.location.href='../Student/AddStuMsg';</script>");
            }
        }
        #endregion
    }
}