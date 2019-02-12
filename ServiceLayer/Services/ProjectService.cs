using DATALayer.Domain;
using DATALayer.Infrastucture;
using RepositryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.ViewModels;

namespace ServiceLayer.Services
{
    //Common service to manipulate different data of diffrent Entities
    public class ProjectService : IProjectService
    {
        private readonly IEntityBaseRepositry<Project> _projectData;  //interface type variable to get all project data
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IEntityBaseRepositry<Project> projectData, IUnitOfWork unitOfWork) 
        {
            this._projectData = projectData;
            this._unitOfWork = unitOfWork;
        }


        //Method to get all data of Project table//
        public IEnumerable<Project> GetAll() 
        {

            return _projectData.GetAll().ToList();
        }


        /// <summary>
        /// Author:Piyush Joshi.
        /// Created On: 30-Nov-2016
        /// Method to save Project data into Project tables.
        /// </summary>
        /// <param name="data"></param>
       
        public void Save(Project data)
        {
           
            if (data.ProjectID == null) //generate random id if projectID is null//
            {

                var threeCharFromTitle = data.Title.Substring(0, 3); //splitting the project title//
                int randomNum = (new Random()).Next(100, 10000);

                data.ProjectID  = threeCharFromTitle + randomNum.ToString();
           
                 _projectData.Save(data);
                _unitOfWork.Commit();
            }
            else
            {
                _projectData.Save(data);
                _unitOfWork.Commit();
            }
        
           
        }


        /// <summary>
        /// Author:Piyush Joshi.
        /// Created On:30-Nov-2016
        /// </summary>
        /// <param name="data"></param>

        #region searching,sorting,pagination

        public IEnumerable<ProjectGridViewModel> GetDataList(string search, int page, int itemsPerPage = 5, string sortBy = " ")
        {
               var ListProject = _projectData.GetDataList(search,page,itemsPerPage,sortBy);

/////////////////////
               IEnumerable<Project> listOfProject = _projectData.GetDataList(search, page, itemsPerPage, sortBy);

               List<ProjectGridViewModel> projectViewModel = new List<ProjectGridViewModel>();


               foreach (var data in listOfProject)
               {
                   projectViewModel.Add(new ProjectGridViewModel { ID = data.ID, ProjectID = data.ProjectID, Title = data.Title, SmallDescription = data.SmallDescription, LongDescription = data.LongDescription, StartDate = data.StartDate, EndDate = data.EndDate, TimeZone = data.TimeZone, ParentProjectName = GetParentProjectName(data.ParentProjectID) });
               }


               IEnumerable<ProjectGridViewModel> ProjectGrid = projectViewModel.AsEnumerable();      
///////////////////

               if (!string.IsNullOrWhiteSpace(search))
               {
                   search = search.ToLower();
                   ProjectGrid = ProjectGrid.Where(x =>
                       x.Title.ToLower().Contains(search) ||
                       x.SmallDescription.ToLower().Contains(search));


               }

               var usersPaged = ProjectGrid.OrderByDescending(x => x.ID).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

               if (sortBy == "SmallDescription")
               {
                   usersPaged = ProjectGrid.OrderBy(x => x.SmallDescription).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
               }
               else if (sortBy == "Title")
               {
                   usersPaged = ProjectGrid.OrderBy(x => x.Title).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

               }
               else if (sortBy == "ProjectID")
               {
                   usersPaged = ProjectGrid.OrderBy(x => x.ProjectID).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

               }

               return usersPaged.ToList();
        }
        #endregion






        /// <summary>
        /// Method to find Parent project on the basis of ID
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>

        public string GetParentProjectName(int? ParentID)
        {
            string data;
            if (ParentID == null || ParentID == 0)
            {
                return data = "No Parent Assigned";
            }
            else { 
         return GetAll().Where(x => x.ID == ParentID).SingleOrDefault().Title;
        }
        }
    }


}
