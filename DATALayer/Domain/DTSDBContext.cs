using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATALayer.Domain
{
    public class EmahaSchoolEntities : DbContext
    {
        public EmahaSchoolEntities()
            : base("name=DTSContext")
        {
                
        }
  
        #region Entity Sets
        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Defect> Defects { get; set; }

        public IDbSet<Attachment> Attachments { get; set; }

        public IDbSet<DefectStatus> DefectStatuses { get; set; }

        public IDbSet<Priority> Priorities { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
