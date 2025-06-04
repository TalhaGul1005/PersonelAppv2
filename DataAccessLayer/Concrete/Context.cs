using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<PTO> PTOs { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
