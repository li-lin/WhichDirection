using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Helper
{
    public class TeIsLoginIn : ActionFilterAttribute
    {
        /// <summary>
        /// 当前登陆用户名
        /// </summary>
        public static string userName { get; set; }

        public static Teacher GetUser()
        {
            using (WdDbContext db = new WdDbContext())
            {
                var user = new Teacher();
                user = db.Teachers.Where(x => x.LoginName == userName).FirstOrDefault();
                return user;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpContext.Current.Response.Write("OnActionExecuting:正要准备执行Action的时候但还未执行时执行<br />");    
            if (userName == null)
            {
                HttpContext.Current.Response.Write("<script>alert('当前未登录！');window.parent.location.href='/Login/Login'</script>");
                HttpContext.Current.Response.End();
                return;
            }
        }
    }
}