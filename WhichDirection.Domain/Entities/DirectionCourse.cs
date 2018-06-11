using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    /// <summary>
    /// 方向与考核课程对应关系
    /// </summary>
    public class DirectionCourse
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public Direction Direction { get; set; }
        /// <summary>
        /// 课程在该方向所在比重
        /// </summary>
        public double Proportion { get; set; }
    }
}
