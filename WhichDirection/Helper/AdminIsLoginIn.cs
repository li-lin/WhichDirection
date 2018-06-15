using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhichDirection.Core;
using WhichDirection.Domain.Entities;
using WhichDirection.Domain;

namespace WhichDirection.Helper
{
    public class AdminIsLoginIn: ActionFilterAttribute
    {
        /// <summary>
        /// 登录用户保存
        /// </summary>
        public static string userName { get; set; }

        public static User GetUser()
        {
            using(WdDbContext db=new WdDbContext())
            {
                var user = new User();
                user = db.Users.Where(x => x.LoginName == userName).FirstOrDefault();
                return user;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //HttpContext.Current.Response.Write("OnActionExecuting:正要准备执行Action的时候但还未执行时执行<br />");    
            if (userName == null )
            {
                HttpContext.Current.Response.Write("<script>alert('先去登陆吧');window.parent.location.href='/Login/Login'</script>");
                HttpContext.Current.Response.End();
                return;
            }
        }
    }
}