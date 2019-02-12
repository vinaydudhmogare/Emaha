using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.ViewModels
{
    public class DefectFileViewModel
    {
        
        public int DefectID { get; set; }
    
        public int ProjectID { get; set; }
    
        public string Title { get; set; }

        public string SmallDescription { get; set; }

        public string LongDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpireyDate { get; set; }

        public int PriorityID { get; set; }

        public int StatusID { get; set; }
     
    }

    public class DefectDocuments
    {
        public int DefectID { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; }
    }
}

