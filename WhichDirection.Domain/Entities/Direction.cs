using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Direction
    {
        public Direction()
        {
            this.DirectionOrder = new HashSet<DirectionOrder>();
        }


        public int DId { get; set; }
        public string Description { get; set; }
        public string TeacherName { get; set; }


        public ICollection<DirectionOrder> DirectionOrder { get; set; }
    }
}
