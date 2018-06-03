﻿using System;
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
        #region 查询学生信息
        /// <summary>
        /// 通过学号或者专业查询学生信息
        /// </summary>
        /// <param name="msg">姓名或者专业</param>
        /// <returns></returns>
        public IQueryable<Student> GetStudent(string msg)
        {
            var stulist = dbContext.Students.Where(x => x.Name == msg);
            if (stulist == null)
            {
                stulist = dbContext.Students.Where(x => x.Major == msg);
            }
            return stulist;
        }
        #endregion
        #region 查询学生信息
        /// <summary>
        /// 通过学号获取学生信息
        /// </summary>
        /// <param name="sid">学号</param>
        /// <returns></returns>
        public Student GetStuInfo(string sid)
        {
            var stu = dbContext.Students.Where(x => x.LoginName == sid).FirstOrDefault();
            return stu;
        }
        /// <summary>
        /// 通过学生姓名或者专业名称获取学生信息
        /// </summary>
        /// <param name="nameOrmaior">学生姓名或者专业名称</param>
        /// <returns></returns>
        public IQueryable<Student> GetStuInfo(string nameOrmaior)
        {
            var stulist = dbContext.Students.Where(x => x.Name == nameOrmaior);
            if (stulist == null)
            {
                stulist = dbContext.Students.Where(x => x.Major == nameOrmaior);
            }
            return stulist;
        }
        #endregion
        #region 添加/修改学生信息
        /// <summary>
        /// 添加或者修改学生信息
        /// </summary>
        /// <param name="student">Student 对象</param>
        /// <returns></returns>
        public bool AddStudent(Student student)
        {
            if (dbContext.Students.Where(x => x.Id == student.Id).FirstOrDefault() == null)
            {
                dbContext.Students.Add(student);
            }
            else
            {
                var dir = dbContext.Students.Where(x => x.Id == student.Id).FirstOrDefault();
                dir.Major = student.Major;
                dir.LoginName = student.LoginName;
                dir.Name = student.Name;
                dir.Pwd = student.Pwd;
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
        #region 删除学生信息
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="studentlist">学号集合</param>
        /// <returns></returns>
        public bool deleteStu(List<string> stuNumber)
        {
            foreach (string n in stuNumber)
            {
                var stu = dbContext.Students.Where(x => x.LoginName == n).FirstOrDefault();
                dbContext.Students.Remove(stu);
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
