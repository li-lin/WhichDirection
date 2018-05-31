using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhichDirection.Domain;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Core
{
    /// <summary>
    /// 学生信息管理
    /// 1、导入，将视图中上传的Excel文件中学生数据（包括各科成绩）导入数据库。
    /// 2、查询，通过学生学号/姓名/专业查询学生信息。
    /// 3、添加，添加单个学生信息。
    /// 4、修改，修改单个学生信息。
    /// 5、删除，删除单个/多个学生信息。
    /// </summary>
    public class StudentManage
    {
        WdDbContext dbContext = new WdDbContext();
        #region 获取学生信息
        public Student GetStuInfo(int sid)
        {
            var stu = dbContext.Students.Where(x => x.Number == sid).FirstOrDefault();
            return stu;
        }
        public IQueryable<Student> GetStuInfo(string name)
        {
            var stulist = dbContext.Students.Where(x => x.Name == name);
            return stulist;
        }
        public IQueryable<Student> GetStuInfoByMajor(string major)
        {
            var stulist = dbContext.Students.Where(x => x.Major == major);
            return stulist;
        }
        #endregion
        #region 添加/修改学生信息
        public bool AddStudent(Student student)
        {
            if (dbContext.Students.Where(x => x.SId == student.SId).FirstOrDefault() == null)
            {
                dbContext.Students.Add(student);
            }
            else
            {
                var dir = dbContext.Students.Where(x => x.SId == student.SId).FirstOrDefault();
                dir.Major = student.Major;
                dir.Major = student.Name;
                dir.Number = student.Number;   
                dir.Password = student.Password;
            }
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
