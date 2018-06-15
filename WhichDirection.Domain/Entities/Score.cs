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
        /// 成绩得分
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// 学生的课程
        /// </summary>
        public virtual Course Course { get; set; }
        /// <summary>
        /// 学生
        /// </summary>
        public virtual Student Student { get; set; }
    }
}
