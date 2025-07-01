using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.DataContext;
using BLL.Data.Entities;

namespace BLL.Repo
{
    public class UserRepository 
    {
        private readonly Context _context;
        public UserRepository(Context context) 
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
        public void Delete(User u)
        {
            _context.Remove(u);
            _context.SaveChanges();
        }

        public List<User> GetList()
        {
            return _context.Set<User>().ToList();
        }

        public void Insert(User u)
        {
            _context.Add(u);
            _context.SaveChanges();
        }

        public void Update(User u)
        {
            _context.Update(u);
            _context.SaveChanges();
        }

        
    }
}
