using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.DataContext;
using BLL.Data.Entities;

namespace BLL.Repo
{
    public class PTORepository
    {
        private readonly Context _context;
        public PTORepository(Context context) 
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
        public List<PTO> GetList()
        {
            return _context.Set<PTO>().ToList();
        }

        public void Insert(PTO p)
        {
            _context.Add(p);
            _context.SaveChanges();
        }

        public void Update(PTO p)
        {
            _context.Update(p);
            _context.SaveChanges();
        }
    }
}
