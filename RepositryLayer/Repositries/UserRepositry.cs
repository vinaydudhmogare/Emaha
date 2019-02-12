using DATALayer;
using RepositryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryLayer.Repositries
{
    public class UserRepositry : IUserRepositry
    {
         public static List<User> us = new List<User>()
         {
             new User{id = 1, Name="Piyush"}
         };
        public List<User> GetAll()
        {
           return us;
        }
    }
}
