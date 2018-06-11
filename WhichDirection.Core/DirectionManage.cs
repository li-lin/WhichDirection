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
    /// 方向信息管理
    /// 1、添加，添加方向信息
    /// 2、修改，修改方向信息/方向负责教师/方向考核课程/录取人数上限
    /// 3、删除，删除方向信息
    /// 4、查询，根据方向名获取方向信息
    /// </summary>
    public class DirectionManage
    {
        WdDbContext dbContext = new WdDbContext();
        #region 添加/修改方向信息
        /// <summary>
        /// 添加或修改方向信息
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool AddDirection(Direction direction)
        {
            Direction dir = dbContext.Directions.Where(x => x.Id == direction.Id).FirstOrDefault();
            if (dir == null)
            {
                dbContext.Directions.Add(direction);
            }
            else
            {
                dir.Name = direction.Name;
                dir.Max = 30;
                dir.Director = direction.Director;
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
        #region 删除方向信息
        /// <summary>
        /// 删除方向信息
        /// </summary>
        /// <param name="id">方向对应ID</param>
        /// <returns></returns>
        public bool DeleteDirection(int id)
        {
            Direction dir = dbContext.Directions.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Directions.Remove(dir);
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
        #region 查询方向信息
        /// <summary>
        /// 查询方向信息
        /// </summary>
        /// <param name="directionName">方向名称</param>
        /// <returns></returns>
        public Direction GetDirection(string directionName)
        {
            Direction dir = dbContext.Directions.Where(x => x.Name == directionName).FirstOrDefault();
            return dir;
        }

        /// <summary>
        /// 根据方向负责人获取方向信息
        /// </summary>
        /// <param name="teacher">方向负责人</param>
        /// <returns></returns>
        public Direction GetDirection(Teacher teacher)
        {
            Direction dir = dbContext.Directions.SingleOrDefault(d => d.Director.Id == teacher.Id);
            return dir;
        }
        #endregion
        #region 获取所有方向信息
        /// <summary>
        /// 获取所有方向信息
        /// </summary>
        /// <returns></returns>
        public IList<Direction> GetAllDirection()
        {
            var list = from n in dbContext.Directions
                       select n;
            return list.ToList<Direction>();
        }
        #endregion
        
        /// <summary>
        /// 设置(添加/修改)方向与考核课程对应关系和占比
        /// </summary>
        /// <param name="direction">方向</param>
        /// <param name="course">课程</param>
        /// <param name="proportion">占比</param>
        /// <returns>是否设置成功</returns>
        public bool SetDirectionCourseProportion(Direction direction,Course course, double proportion)
        {
            bool b = false;
            DirectionCourse dc = dbContext.DirectionCourses.SingleOrDefault(item => item.Course.Id == course.Id && item.Direction.Id == direction.Id);
            if (dc == null)
            {
                dc = new DirectionCourse
                {
                    Direction = direction,
                    Course = course,
                    Proportion = proportion
                };
                dbContext.DirectionCourses.Add(dc);
            }
            else
            {
                dc.Proportion = proportion;
            }
            int i = dbContext.SaveChanges();
            if (i > 0)
            {
                b = true;
            }
            return b;
        }
    }
}
