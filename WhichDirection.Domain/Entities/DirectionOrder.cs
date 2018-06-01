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
        public int Order { get; set; }
        
        public Direction Directions { get; set; }
        public Student Students { get; set; }
    }
}
