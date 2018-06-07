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
    /// 对系统相关配置信息进行管理
    /// 1、志愿填报截止日期管理。
    /// 2、...
    /// </summary>
    public class ServerConfiguration
    {
        #region 截止时间
        /// <summary>
        /// 是否已经截止
        /// </summary>
        /// <param name="cutoffTime">截止时间</param>
        /// <returns>是否截止</returns>
        public static bool IsOverTime(DateTime cutoffTime)
        {
            bool b = false;
            using (var db = new WdDbContext())
            {
                var config = db.ServerConfigurations.FirstOrDefault();
                if (config != null)
                {
                    DateTime deadline = config.Deadline;
                    if (cutoffTime <= deadline)
                    {
                        b = true;
                    }
                }
            }
            return b;
        }

        /// <summary>
        /// 设置截止时间
        /// </summary>
        /// <param name="theTime">截止时间</param>
        /// <returns>是否设置成功</returns>
        public static bool SetDeadline(DateTime theTime)
        {
            bool b = false;
            using (var db = new WdDbContext())
            {
                var config = db.ServerConfigurations.FirstOrDefault();
                if (config != null)
                {
                    config.Deadline = theTime;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        b = true;
                    }
                }
            }
            return b;
        }
        #endregion
    }
}
