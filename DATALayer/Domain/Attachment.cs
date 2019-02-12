using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATALayer.Domain
{
     public class Attachment
    {
         public int ID { get; set; }

         //[ForeignKey("DefectID")]
         //public Defect Defekt { get; set; }

         public int? DefectID { get; set; }

         public string OrignalFileName { get; set; }

         public string FileName { get; set; }

         public string Size { get; set; }

         public string FilePath { get; set; }

         public int? ProjectID { get; set; }

         //[ForeignKey("ProjectID")]
         //public Project Project { get; set; }

         public Nullable<bool> IsDeleted { get; set; }
    }
}
