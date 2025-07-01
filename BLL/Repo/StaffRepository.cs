using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.DataContext;
using BLL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repo
{
    public class StaffRepository 
    {
        private readonly Context _context;
        public StaffRepository (Context context) 
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
        public List<Staff> GetList()
        {
            return _context.Set<Staff>().ToList();
        }

        public void Insert(Staff s)
        {
            _context.Add(s);
            _context.SaveChanges();
        }

        public void Update(Staff s)
        {
            _context.Update(s);
            _context.SaveChanges();
        }


    }
}
