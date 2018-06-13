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
                    Deadline = new DateTime(2018, 7, 30)
                };
                db.ServerConfigurations.Add(config);

                var teacher1 = new Teacher
                {
                    LoginName = "JC01",
                    Pwd = "123456",
                    IsTeacher = true,
                    IsAdmin = false,
                    Name = "李小林"
                };
                var teacher2 = new Teacher
                {
                    LoginName = "JC02",
                    Pwd = "123456",
                    IsTeacher = true,
                    IsAdmin = true,
                    Name = "林小李"
                };
                var student = new Student
                {
                    LoginName = "20160000",
                    Pwd = "123456",
                    IsTeacher = false,
                    Gender="男",
                    IsCompleted = false,
                    Major = "软件工程",
                    Name = "王小二"
                };
                db.Teachers.Add(teacher1);
                db.Teachers.Add(teacher2);
                db.Students.Add(student);

                db.SaveChanges();
            }
        }
    }
}
