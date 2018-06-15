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
        WdDbContext  dbContext = new WdDbContext();

        #region 查询教师信息
        /// <summary>
        /// 查询教师信息（工号）
        /// </summary>
        /// <param name="number">工号</param>
        /// <returns></returns>
        public Teacher GetTeacherByNumber(string number)
        {
            return dbContext.Teachers.Where(t => t.LoginName == number).FirstOrDefault();
        }

        /// <summary>
        /// 查询教师信息（姓名）
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        public Teacher GetTeacherByName(string name)
        {
            Teacher teacher = dbContext.Teachers.Where(t => t.Name == name).FirstOrDefault();
            return teacher;
        }

        /// <summary>
        /// 查询教师信息（方向名）
        /// </summary>
        /// <param name="directionName">方向名</param>
        /// <returns></returns>
        public Teacher GetTeacherByDirection(string directionName)
        {
            return dbContext.Teachers.Where(t => t.Direction.Name == directionName).FirstOrDefault();
        }

        /// <summary>
        /// 获取所有教师信息
        /// </summary>
        /// <returns>所有教师信息列表</returns>
        public IList<Teacher> GetTeachers()
        {
            var query = from t in dbContext.Teachers
                        select t;
            return query.ToList<Teacher>();
        }
        #endregion

        #region 添加/修改教师信息
        /// <summary>
        /// 添加教师信息
        /// </summary>
        /// <param name="teacher">教师对象</param>
        /// <returns>是否添加成功</returns>
        public bool AddTeacher(Teacher teacher)
        {
            bool b = false;
            Teacher t = dbContext.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault();
            if (t == null)
            {
                dbContext.Teachers.Add(teacher);

                int i = dbContext.SaveChanges();
                if (i > 0)
                {
                    b = true;
                }
            }
            return b;
        }

        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="teacher">包含新信息的教师</param>
        /// <returns>是否修改成功</returns>
        public bool ModifyTeacher(Teacher teacher)
        {
            bool b = false;
            Teacher t = dbContext.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault();
            if (t != null)
            {
                t.LoginName = teacher.LoginName;
                t.Name = teacher.Name;
                t.Pwd = teacher.Pwd;
                t.Direction = teacher.Direction;
                t.IsTeacher = teacher.IsTeacher;
                t.IsAdmin = teacher.IsAdmin;

                int i = dbContext.SaveChanges();
                if (i > 0)
                {
                    b = true;
                }
            }
            return b;
        }
        #endregion

        #region 删除教师信息
        /// <summary>
        /// 删除教师信息
        /// </summary>
        /// <param name="teacher">需要删除的教师</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteTeacher(Teacher teacher)
        {
            bool b = false;
            var t = dbContext.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault();
            if (t != null)
            {
                dbContext.Teachers.Remove(t);

                int i = dbContext.SaveChanges();
                if (i > 0)
                {
                    b = true;
                }
            }
            return b;
        }
        #endregion

        #region 教师权限设置
        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="teacher">教师</param>
        /// <param name="authority">权限</param>
        /// <returns></returns>
        public bool SetAuthority(Teacher teacher, bool authority)
        {
            bool b = false;
            Teacher t = dbContext.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault();
            t.IsAdmin = authority;

            int i = dbContext.SaveChanges();
            if (i > 0)
            {
                b = true;
            }
            return b;
        }
        #endregion
        
    }
}
