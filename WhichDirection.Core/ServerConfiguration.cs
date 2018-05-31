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
        public static bool isOverTime()
        {
            bool b = false;
            string strDeadline = "";
            DateTime deadline = DateTime.Parse(strDeadline);
            if (deadline <= DateTime.Now)
            {
                b = true;
            }
            return b;
        }
    }
}
