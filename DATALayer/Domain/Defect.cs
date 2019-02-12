using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATALayer.Domain
{
    public class Defect
    {
        public Defect()
        {
            //Attachment = new List<Attachment>();    
        }

        public int ID { get; set; }

        public string Title { get; set; }
 
        public string SmallDescription { get; set; }

        public string LongDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpireyDate { get; set; }

        public int? StatusID { get; set; }

        //[ForeignKey("ProjectID")]
        //public Project Projekt { get; set; }

        public int ProjectID { get; set; }

        //public ICollection<Attachment> Attachment { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        public int? PriorityID { get; set; }

        
    }
}
