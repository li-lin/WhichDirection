using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WhichDirection.Core;
using WhichDirection.Domain.Entities;
using WhichDirection.Helper;
using WhichDirection.Models;

namespace WhichDirection.Controllers
{
    [StuIsLoginIn]
    public class ChoiceController : Controller
    {
        private static List<int> testData1 = new List<int> { 3, 2, 1 };
        private static List<int> testData2 = new List<int> { 1, 2, 3 };
        StudentManage s = new StudentManage();
        DirectionSelector d = new DirectionSelector();
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

        public ActionResult Select(string jsonText)
        {
            //格式：key:方向  value:对应排序
            //无法直接将json转换为int,int做了个过渡操作
            int x, y;
            var user = StuIsLoginIn.GetUser();
            JavaScriptSerializer sa = new JavaScriptSerializer();
            Dictionary<int, int> jsonData2 = new Dictionary<int, int>();
            Dictionary<string, string> JsonData1 = sa.Deserialize<Dictionary<string, string>>(jsonText);
            foreach(var n in JsonData1)
            {
                x = int.Parse(n.Key);
                y = int.Parse(n.Value);
                jsonData2.Add(x, y);
            }
            if(d.SelectDirection(user, jsonData2))
            {
                user.IsCompleted = true;
                s.AddStudent(user);
                return Content("<script>alert('选择成功！');window.location.href='../Choice/Index';</script>");
            }
            return Content("<script>alert('选择失败！');window.location.href='../Choice/Index';</script>");
        }
    }
}