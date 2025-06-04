using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfDepartmentDal : GenericRepository<Department>, IDepartmentDal
    {
        private readonly Context _context;
        public EfDepartmentDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
