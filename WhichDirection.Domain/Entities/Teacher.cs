﻿using System;
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

        public string Department { get; set; }
        public IList<Direction> Directions { get; set; }
    }
}
