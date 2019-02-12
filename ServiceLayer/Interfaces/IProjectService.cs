using DATALayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();

        void Save(Project data);

        //IEnumerable<Project> GetDataList(string search, int page, int itemsPerPage = 5, string sortBy = " ");

        IEnumerable<ProjectGridViewModel> GetDataList(string search, int page, int itemsPerPage = 5, string sortBy = " ");

        string GetParentProjectName(int? ParentID);
    }
}
