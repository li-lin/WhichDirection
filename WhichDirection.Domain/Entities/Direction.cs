using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WhichDirection.Domain.Entities
{
    public class Direction
    {
        /// <summary>
        /// 方向ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 方向名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 填报人数上限
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// 方向负责老师
        /// </summary>
        [Required]
        public virtual Teacher Director { get; set; }
    }
}
