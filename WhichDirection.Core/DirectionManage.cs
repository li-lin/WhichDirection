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
        /// 根据传入的model判断
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool AddDirection(Direction direction)
        {
            if (dbContext.Direction.Where(x => x.Id == direction.Id).FirstOrDefault() == null)
            {
                dbContext.Direction.Add(direction);
            }
            else
            {
                Direction dir = dbContext.Direction.Where(x => x.Id == direction.Id).FirstOrDefault();
                dir.Name = direction.Name;
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
            Direction dir = dbContext.Direction.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Direction.Remove(dir);
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
            Direction dir = dbContext.Direction.Where(x => x.Name == directionName).FirstOrDefault();
            return dir;
        }
        #endregion
        #region 获取所有方向信息
        /// <summary>
        /// 获取所有方向信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Direction> GetAllDirection()
        {
            var list = from n in dbContext.Direction
                       select n;
            return list;
        }
        #endregion
    }
}
