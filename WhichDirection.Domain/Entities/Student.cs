using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Student:User
    {        /// <summary>
        /// 专业
        /// </summary>
        public string Major { get; set; }
        /// <summary>
        /// 是否完成方向选择
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
