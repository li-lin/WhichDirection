using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Score
    {
        public Score()
        {
            Courses = new List<Course>();
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public float Grade { get; set; }

        public IList<Course> Courses { get; set; }
        public IList<Student> Students { get; set; }
    }
}
