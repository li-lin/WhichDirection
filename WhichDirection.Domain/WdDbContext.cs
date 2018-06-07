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
        {
            Database.SetInitializer<WdDbContext>(new WdDbInitializer()); //添加自定义数据初始化器。
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Direction> Direction { get; set; }

        public DbSet<DirectionOrder> DirectionOrders { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ServerConfig> ServerConfigurations { get; set; }
    }
}
