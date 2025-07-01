using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;
using BLL.Repo;

namespace BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _User;

        public UserService(UserRepository user)
        {
            _User = user;
        }
        public User Validate(string userName, string password)
        {
            return _User.GetUser(userName, password);
        }
    }
}
