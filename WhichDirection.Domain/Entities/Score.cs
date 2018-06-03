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
        public float Grade { get; set; }

        public Course Courses { get; set; }
        public Student Students { get; set; }
    }
}
