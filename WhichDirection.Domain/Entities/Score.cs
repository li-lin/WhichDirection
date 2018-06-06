using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Score
    {
        public int Id { get; set; }
        /// <summary>
        /// 成绩
        /// </summary>
        public float Grade { get; set; }

        /// <summary>
        /// 学生的课程
        /// </summary>
        public Course Courses { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        public Student Students { get; set; }
    }
}
