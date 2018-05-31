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
        public bool AddDirection(Direction direction)
        {
            if (dbContext.Directions.Where(x => x.DId == direction.DId).FirstOrDefault() == null)
            {
                dbContext.Directions.Add(direction);
            }
            else
            {
                Direction dir = dbContext.Directions.Where(x => x.DId == direction.DId).FirstOrDefault();
                dir.Description = direction.Description;
                dir.TeacherName = direction.Description;
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
            Direction dir = dbContext.Directions.Where(x => x.DId == id).FirstOrDefault();
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
            Direction dir = dbContext.Directions.Where(x => x.Description == directionName).FirstOrDefault();
            return dir;
        }
        #endregion
    }
}
