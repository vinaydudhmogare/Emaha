using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.ViewModels
{
    public class ProjectGridViewModel
    {
        public ProjectGridViewModel()
        {
                
        }
        public int ID { get; set; }

        public string ProjectID { get; set; }

        public string Title { get; set; }

        public string SmallDescription { get; set; }

        public string LongDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TimeZone { get; set; }

        public string ParentProjectID { get; set; }

        public string ParentProjectName { get; set; }




    }
}
