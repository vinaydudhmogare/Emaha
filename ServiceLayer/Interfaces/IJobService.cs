using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IJobService
    {
        IEnumerable<SalesUser> GetAll_JobUsers();

        void Save_JobsUser(Job obj_JobUser);

    }
}
