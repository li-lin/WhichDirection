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
    /// 教师信息管理
    /// 1、查询，根据教师工号/姓名/方向获取教师信息。
    /// 2、添加，添加单个教师信息。
    /// 3、修改，修改单个教师信息。
    /// 4、删除，删除单个/多个教师信息。
    /// 5、权限管理，可以为不同的教师设置管理员权限。
    /// </summary>
    public class TeacherManage
    {
        WdDbContext dbContext = new WdDbContext();
        #region 查询教师信息
        /// <summary>
        /// 查询教师信息
        /// </summary>
        /// <param name="msg">工号/姓名/方向</param>
        /// <returns></returns>
        public Teacher GetTeacher(string msg)
        {
            if (dbContext.Teachers.Where(x => x.LoginName == msg).FirstOrDefault() != null)
            {
                return dbContext.Teachers.Where(x => x.LoginName == msg).FirstOrDefault();
            }
            else if (dbContext.Teachers.Where(x => x.Name == msg).FirstOrDefault() != null)
            {
                return dbContext.Teachers.Where(x => x.Name == msg).FirstOrDefault();
            }
            else if (dbContext.Teachers.Where(x => x.Department == msg).FirstOrDefault() != null)
            {
                return dbContext.Teachers.Where(x => x.Department == msg).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 添加/修改教师信息
        /// <summary>
        /// 添加/修改教师信息
        /// </summary>
        /// <param name="teacher">教师对象</param>
        /// <returns></returns>
        public bool AddTeacher(Teacher teacher)
        {
            if (dbContext.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault() == null)
            {
                dbContext.Teachers.Add(teacher);
            }
            else
            {
                Teacher t = dbContext.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault();
                t.LoginName = teacher.LoginName;
                t.Name = teacher.Name;
                t.Pwd = teacher.Pwd;
                t.Department = teacher.Department;
                t.IsTeacher = true;
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
        #region 删除教师信息
        /// <summary>
        /// 删除教师信息
        /// </summary>
        /// <param name="id">教师ID</param>
        /// <returns></returns>
        public bool DeleteTeacher(int id)
        {
            var t = dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Teachers.Remove(t);
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
        #region 教师权限设置
        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">教师ID</param>
        /// <param name="authority">权限</param>
        /// <returns></returns>
        public bool AddAuthority(int id, bool authority)
        {
            Teacher t = dbContext.Teachers.Where(x => x.Id == id).FirstOrDefault();
            t.IsAdmin = authority;
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
        #region 获取所有教师信息
        public IQueryable<Teacher> GetAllTeacher()
        {
            var list = from n in dbContext.Teachers
                       select n;
            return list;
        }
        #endregion
    }
}
