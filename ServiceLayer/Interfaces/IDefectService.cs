using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IDefectService
    {
        int SaveDefect(Defect data);

        IEnumerable<Defect> GetAllDefect();
      
        int SaveDefectViewModel(DefectFileViewModel data);

        void SaveAttachment(DefectDocuments documents);

        IEnumerable<Project> GetAllProject();

        string GetSingleProject(int ID);

        string GetStatusName(int? ID);

        IEnumerable<DefectStatus> GetAllStatus();

        string GetPriorityName(int? ID);

        IEnumerable<Priority> GetAllPriority();

        IEnumerable<DefectGridViewModel> GetDefectList(string search, int page, int itemsPerPage = 5, string sortBy = " ");

    }
}
