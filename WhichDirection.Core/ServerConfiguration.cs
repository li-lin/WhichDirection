using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 是否已经截至
        /// </summary>
        /// <param name="cutoffTime">截至时间</param>
        /// <returns></returns>
        public static bool isOverTime(string cutoffTime)
        {
            bool b = false;
            DateTime deadline = DateTime.Parse(cutoffTime);
            if (deadline <= DateTime.Now)
            {
                b = true;
            }
            return b;
        }
        #endregion
    }
}
