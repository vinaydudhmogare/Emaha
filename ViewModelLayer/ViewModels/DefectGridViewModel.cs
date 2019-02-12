using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.ViewModels
{
    public class DefectGridViewModel
    {
        public int ID { get; set; }
 
        public int ProjectID { get; set; }

        public int DefectID { get; set; }

        public string Title { get; set; }

        public string SmallDescription { get; set; }

        public string LargeDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpireyDate { get; set; }

        public string ProjectName { get; set; }

        public string StatusName { get; set; }

        public string PriorityName { get; set; }

    }
}
