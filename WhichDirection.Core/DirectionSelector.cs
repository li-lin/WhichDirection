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
    /// 方向选择
    /// 1、记录学生选择的方向。
    /// 2、根据方向查询学生选择方向情况（主要根据第1-18志愿排序，用于方向负责教师了解情况）。
    /// 3、根据成绩和志愿录取学生。
    /// 4、根据方向查询学生录取情况。
    /// 5、获取全部学生录取情况（仅管理员）。
    /// 6、学生查询个人录取情况（待定）。
    /// </summary>
    public class DirectionSelector
    {
        WdDbContext dbContext = new WdDbContext();
        #region 记录学生选择
        /// <summary>
        /// 将选择顺序保存至数据库
        /// </summary>
        /// <param name="stu">学生</param>
        /// <param name="directionOrders">方向Id和排序的键值对</param>
        /// <returns></returns>
        public bool SelectDirection(string name,Dictionary<int,int> directionOrders)
        {
            foreach(var item in directionOrders)
            {
                DirectionOrder dd = new DirectionOrder();
                dd.Order = item.Value;
                dd.Student = dbContext.Students.Where(x=>x.LoginName==name).FirstOrDefault();
                dd.Direction = dbContext.Directions.SingleOrDefault(d => d.Id == item.Key);
                if (dd.Direction == null)
                {
                    throw new Exception($"系统错误：方向[{item.Key}]信息未找到！");
                }
                else
                {
                    dbContext.DirectionOrders.Add(dd);
                }
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
