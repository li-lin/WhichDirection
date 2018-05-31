using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            this.DirectionOrder = new HashSet<DirectionOrder>();
        }

        public int SId { get; set; }
        public int Number { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public float Grade { get; set; }

        public ICollection<DirectionOrder> DirectionOrder { get; set; }
    }
}
