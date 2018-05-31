using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WhichDirection.Domain.Entities;

namespace WhichDirection.Domain
{
    public class WdDbContext : DbContext
    {
        public WdDbContext()
            : base("name=connStr")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<DirectionOrder> DirectionOrders { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
