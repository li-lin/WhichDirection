using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhichDirection.Core;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //test1();
            test2();

            Console.WriteLine("done");
            Console.ReadKey();
        }

        static void test1()
        {
            using (var db=new WdDbContext())
            {
                var s = new Student()
                {
                    LoginName = "20081101",
                    Name = "yh",
                    Pwd = "123456",
                    Major = "cs",
                    IsTeacher = false
                };
                var t = new Teacher()
                {
                    LoginName = "JC200803040",
                    Name="tr",
                    Pwd = "123456",
                    IsTeacher = true
                };
                var d = new Direction()
                {
                    Name = "dotNET",
                    Director = t
                };
                db.Students.Add(s);
                db.Teachers.Add(t);
                db.Direction.Add(d);
                db.SaveChanges();
            }
        }

        static void test2()
        {
            using (var db = new WdDbContext())
            {
                List<User> ts = db.Users.ToList<User>();
                foreach (var t in ts)
                {
                    if (t.IsTeacher)
                    {
                        var tech = db.Teachers.Include("Directions").FirstOrDefault(tt => tt.Id == t.Id);
                        Console.WriteLine($"UserName:{tech.Name}, Password:{tech.Pwd}, Direction:{tech.Direction.Name}");
                    }
                    else
                    {
                        var stu = t as Student;
                        Console.WriteLine($"UserName:{stu.Name}, Password:{stu.Pwd}, Marjor:{stu.Major}");
                    }
                }
                //DirectionManage dba = new DirectionManage();
                //var dir= dba.GetAllDirection();
                //foreach(Direction x in dir)
                //{
                //    Console.WriteLine("ID:" + x.Id + "Name:" + x.Name);
                //}
            }
        }
    }
}
