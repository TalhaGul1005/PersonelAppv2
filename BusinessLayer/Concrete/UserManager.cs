using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _UserDal;

        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
        }
        public User Validate(string username, string password)
        {
            return _UserDal.GetUser(username,password);
        }
    }
}
