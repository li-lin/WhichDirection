using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Domain
{
    /// <summary>
    /// 数据库初始化器，采用DropCreateDatabaseIfModelChanges策略。
    /// </summary>
    public class WdDbInitializer : DropCreateDatabaseIfModelChanges<WdDbContext>
    {
        protected override void Seed(WdDbContext context)
        {
            base.Seed(context);
            using(var db=new WdDbContext())
            {
                var config = new ServerConfig()
                {
                    Deadline = DateTime.Now.AddDays(30)
                };
                db.ServerConfigurations.Add(config);

                db.SaveChanges();
            }
        }
    }
}
