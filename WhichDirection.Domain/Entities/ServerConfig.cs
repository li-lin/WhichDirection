using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    /// <summary>
    /// 服务器配置数据，只允许有一行数据。
    /// </summary>
    public class ServerConfig
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
    }
}
