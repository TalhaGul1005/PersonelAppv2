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
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        private readonly Context _context;
        public EfUserDal(Context context) : base(context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
