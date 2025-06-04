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
    public class EfPTODal:GenericRepository<PTO>,IPTODal
    {
        private readonly Context _context;
        public EfPTODal(Context context) : base(context)
        {
            _context = context;
        }

        public PTO Find(int id)
        {
            return _context.PTOs.Find(id);
        }

        public void Delete(PTO p)
        {
            _context.PTOs.Remove(p);
            _context.SaveChanges();
        }
    }
}
