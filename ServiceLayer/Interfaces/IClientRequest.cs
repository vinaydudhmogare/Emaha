using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceLayer.Interfaces
{
   public interface IClientRequest
    {
        IEnumerable<ClientRequest> GetAll_ClientRequestUsers();

        void Save_ClientRequestUser(ClientRequest obj_ClientRequestUser);
    }
}
