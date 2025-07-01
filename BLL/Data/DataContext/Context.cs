using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Data.DataContext
{
    
        public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options) : base(options) { }

            public DbSet<Department> Departments { get; set; }
            public DbSet<PTO> PTOs { get; set; }
            public DbSet<Staff> Staffs { get; set; }
            public DbSet<User> Users { get; set; }
        }
    
}
