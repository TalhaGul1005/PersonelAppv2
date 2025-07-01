using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.DataContext;
using BLL.Data.Entities;

namespace BLL.Repo
{
    public class DepartmentRepository 
    {
        private readonly Context _context;
        public DepartmentRepository(Context context) 
        {
            _context = context;
        }
        public void Delete(Department d)
        {
            _context.Remove(d);
            _context.SaveChanges();
        }

        public List<Department> GetList()
        {
            return _context.Set<Department>().ToList();
        }

        public void Insert(Department d)
        {
            _context.Add(d);
            _context.SaveChanges();
        }

        public void Update(Department d)
        {
            _context.Update(d);
            _context.SaveChanges();
        }
    }
}
