using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DATALayer.Domain
{
    public class Project
    {
        public Project()
        {    
           //Defekts = new List<Defect>();    
        
        }

        public int ID { get; set; }

        public string ProjectID { get; set; }
      
        public string Title { get; set; }

        public string SmallDescription { get; set; }

        public string LongDescription { get; set; }

        public DateTime StartDate { get; set; }

        public string TimeZone { get; set; }

        public DateTime EndDate { get; set; }

        public int? ParentProjectID { get; set; }

        //public virtual ICollection<Defect> Defekts { get; set; }

        public Nullable<bool> IsDeleted { get; set; }
    }
}
