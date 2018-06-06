using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Teacher:User
    {
        public Teacher()
        {
            Directions = new List<Direction>();
        }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        public IList<Direction> Directions { get; set; }
    }
}
