using DATALayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryLayer.Interfaces
{
    public interface IUserRepositry
    {
        List<User> GetAll();
    }
}
