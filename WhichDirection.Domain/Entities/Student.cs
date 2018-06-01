using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Student:User
    {
        public Student()
        {
            Directions = new List<Direction>();
        }

        public string Major { get; set; }
        public bool IsCompleted { get; set; }

        public IList<Direction> Directions { get; set; }
    }
}
