using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class DirectionOrder
    {

        public int Id { get; set; }
        /// <summary>
        /// 表示方向顺序
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// 选择的方向
        /// </summary>
        public Direction Direction { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        public Student Student { get; set; }
    }
}
