using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATALayer.Infrastucture
{
    public interface IDbFactory : IDisposable
    {
        EmahaSchoolEntities Init();
    }
}
