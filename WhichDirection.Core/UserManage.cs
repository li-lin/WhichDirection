using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Core
{
    public class UserManage
    {
        public User Login(string loginName,string password)
        {
            User user = null;
            using (var db=new WdDbContext())
            {
                user = db.Users.SingleOrDefault(u => u.LoginName == loginName && u.Pwd == password);                
            }
            return user;
        }
    }
}
