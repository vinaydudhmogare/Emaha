using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    //Common service to manipulate different data of diffrent Entities
   public interface IStatusService
    {
       IEnumerable<DefectStatus> GetAll();
    }
}
