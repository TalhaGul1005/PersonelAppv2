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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        private readonly Context _context;
        public EfStaffDal (Context context) : base (context)
        {
            _context = context;
        }
        public bool AnyTCNo(long TCNo)
        {
            return _context.Staffs.Any(k => k.TCNo == TCNo);
        }

        public void Delete(Staff s)
        {
            _context.Staffs.Remove(s);
            _context.SaveChanges();
        }

        public Staff Find(int StaffId)
        {
            return _context.Staffs.Find(StaffId);
            
        }

        public Staff GetById(int id)
        {
            return _context.Staffs.FirstOrDefault(s => s.Id == id);
        }
    }
}
