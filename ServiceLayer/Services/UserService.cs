using DATALayer;
using RepositryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepositry _userData;
     
        public UserService(IUserRepositry userData)
        {
            this._userData = userData;
        }

        public List<User> GetAll()
        {
            return _userData.GetAll();
        }
    }
}
