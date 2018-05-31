using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Direction { get; set; }
        public int Authority { get; set; }
    }
}
