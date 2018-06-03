using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Pwd { get; set; }
        public bool IsTeacher { get; set; }
    }
}
