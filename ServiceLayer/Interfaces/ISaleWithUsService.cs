using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ISaleWithUsService
    {
        IEnumerable<SalesUser> GetAll_SalesUsers();

        void Save_SalesUser(SalesUser obj_SalesUser);

    }
}
