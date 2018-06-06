using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Direction
    {
        /// <summary>
        /// 方向ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 方向名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 方向负责老师
        /// </summary>
        public Teacher Director { get; set; }
    }
}
