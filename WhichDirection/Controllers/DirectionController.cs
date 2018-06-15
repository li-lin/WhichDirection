using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Core;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;
using WhichDirection.Helper;

namespace WhichDirection.Controllers
{
    [AdminIsLoginIn]
    public class DirectionController : Controller
    {
        DirectionManage di = new DirectionManage();
        // GET: Direction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowDiMsg()
        {
            ViewBag.dimsg = di.GetAllDirection();
            return View();
        }

        public ActionResult AddDiMsgView()
        {
            return View();
        }
        public ActionResult AddDiMsg(string dname, string name,int max)
        {
            Direction direction = new Direction();
            direction.Max = max;
            direction.Name = dname;
            if (di.AddDirection(direction,name))
            {
                return Content("<script>alert('添加信息成功');window.location.href='../Direction/Index';</script>");
            }
            else
            {
                return Content("<script>alert('添加信息失败');window.location.href='../Direction/Index';</script>");
            }
        }
        public ActionResult DirectionDel(int Id)
        {
            bool IsSuccess = di.DeleteDirection(Id);
            if (IsSuccess)
            {
                return RedirectToAction("ShowDiMsg");
            }
            else
            {
                return Json("系统错误", JsonRequestBehavior.AllowGet);
            }
            //}
            //string currentAdmin = Session["admin"] as string;
            //if (string.IsNullOrEmpty(currentAdmin))
            //{
            //    return RedirectToAction("Login", "Home");
            //}

            //var d = this.db.Directions.SingleOrDefault(dd => dd.Id == Id);
            //if (d != null)
            //{
            //    this.db.Directions.Remove(d);
            //    int i = this.db.SaveChanges();
            //    if (i > 0)
            //    {
            //        return PartialView("GetDirections", bindDirectionViewModel());
            //    }
            //}
            
        }

    }
}