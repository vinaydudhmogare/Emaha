using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATALayer.Infrastucture
{
    public class DbFactory : Disposable, IDbFactory
    {
        EmahaSchoolEntities dbContext;

        public EmahaSchoolEntities Init()
        {
            return dbContext ?? (dbContext = new EmahaSchoolEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
