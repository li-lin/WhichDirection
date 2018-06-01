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
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Student> Students { get; set; }
        public Teacher Director { get; set; }
    }
}
