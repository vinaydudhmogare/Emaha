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
    public class DefectService : IDefectService
    {
        private readonly IEntityBaseRepositry<Defect> _defectData; //interface type variable to manipulate all defect data

        private readonly IEntityBaseRepositry<Project> _projectData;

        private readonly IEntityBaseRepositry<Priority> _priorityData;

        private readonly IEntityBaseRepositry<DefectStatus> _defectStatusData; 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityBaseRepositry<Attachment> _attachedFiles;
        public DefectService(IEntityBaseRepositry<Defect> defectData, IUnitOfWork unitOfWork, IEntityBaseRepositry<Attachment> attachedFiles, IEntityBaseRepositry<Project> projectData, IEntityBaseRepositry<DefectStatus> defectStatusData, IEntityBaseRepositry<Priority> priorityData)
        {
            _projectData = projectData;
            _defectData = defectData;
            _unitOfWork = unitOfWork;
            _attachedFiles = attachedFiles;
            _defectStatusData = defectStatusData;
            _priorityData = priorityData;
        }

        //method to save Defect data
        public int SaveDefect(Defect data)
        {
            _defectData.Save(data);
            _unitOfWork.Commit();


            int ID = data.ID;
            return ID;
        }

        //method to return list of all defect//
        public IEnumerable<Defect> GetAllDefect()
        {
           return _defectData.GetAll();
        }


        /// <summary>
        /// Author:Piyush Joshi.
        /// Created On:1-Dec-2016,11:40AM
        /// </summary>
        /// <param name="data"></param>

        #region searching,sorting,pagination

        public IEnumerable<DefectGridViewModel> GetDefectList(string search, int page, int itemsPerPage = 5, string sortBy = " ")
        {
            var ListDefect = _defectData.GetDataList(search, page, itemsPerPage, sortBy);
////////////////////////////
             IEnumerable<Defect> listOfDefect = _defectData.GetDataList(search, page, itemsPerPage, sortBy);

             List<DefectGridViewModel> defectViewModel = new List<DefectGridViewModel>();


             foreach (var data in listOfDefect)
             {
                 defectViewModel.Add(new DefectGridViewModel { ID=data.ID, ProjectID = data.ProjectID, ProjectName = GetSingleProject(data.ProjectID), Title = data.Title, SmallDescription = data.SmallDescription, LargeDescription = data.LongDescription, StartDate = data.StartDate, ExpireyDate = data.ExpireyDate, StatusName = GetStatusName(data.StatusID) ,PriorityName = GetPriorityName(data.PriorityID)});
             }
            
            
                IEnumerable<DefectGridViewModel> DefectGrid =   defectViewModel.AsEnumerable();      

////////////////////////////
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                DefectGrid = DefectGrid.Where(x =>
                    x.Title.ToLower().Contains(search) ||
                    x.SmallDescription.ToLower().Contains(search));

            }

            var usersPaged = DefectGrid.OrderByDescending(x => x.ID).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

            if (sortBy == "SmallDescription")
            {

                usersPaged = DefectGrid.OrderBy(x => x.SmallDescription).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            }
            else if (sortBy == "Title")
            {
                usersPaged = DefectGrid.OrderBy(x => x.Title).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

            }
            else if (sortBy == "StartDate")
            {
                usersPaged = DefectGrid.OrderBy(x => x.StartDate).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

            }

            return usersPaged.ToList();

        }
        #endregion



        /// <summary>
        /// Author:Piyush Joshi.
        /// Created On:5-Dec-2016,2:00PM
        /// </summary>
        /// <param name="data"></param>

        public int SaveDefectViewModel(ViewModelLayer.ViewModels.DefectFileViewModel data)
        {
            Defect defectData = new Defect();

            defectData.Title = data.Title;
            defectData.SmallDescription = data.SmallDescription;
            defectData.ProjectID = data.ProjectID;
            defectData.LongDescription = data.LongDescription;
            defectData.StartDate = data.StartDate;
            defectData.ExpireyDate = data.ExpireyDate;
            defectData.PriorityID = data.PriorityID;
            defectData.StatusID = data.StatusID;
          return SaveDefect(defectData);

        }

        /// <summary>
        /// Author:Piyush Joshi.
        /// Created On:5-Dec-2016,5:22PM
        /// </summary>
        /// <param name="data"></param>
        public void SaveAttachment(DefectDocuments documents)
        {
            Attachment Files = new Attachment();
            Files.DefectID = documents.DefectID;
            Files.OrignalFileName = documents.OriginalFileName;
            Files.FilePath = documents.FilePath;
            _attachedFiles.Save(Files);
            _unitOfWork.Commit();
        }



        /// <summary>
        /// Author:Piyush Joshi.
        /// Methods to Get All Project Based
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetAllProject()
        {
            IEnumerable<Project> dat = _projectData.GetAll();
           return  dat;
        }



        /// <summary>
        /// Author:Piyush Joshi.
        /// Methods to Get Name of Project Based On ID
        /// </summary>
        /// <returns></returns>

        public string GetSingleProject(int ID)
        {
            string data;

            if (ID == null || ID == 0)
            {
                return data = "Not Assigned";
            }
            else { 
            return GetAllProject().Where(x => x.ID == ID).SingleOrDefault().Title;
        }
        }




        /// <summary>
        /// Author:Piyush Joshi.
        /// Methods to Get Name of Status Based On ID
        /// </summary>
        /// <returns></returns>
        public string GetStatusName(int? ID)
        {
            string data;

            if (ID == 0 || ID == null)
            {
               return data = "Not Assigned";
            }
            else { 
            return GetAllStatus().Where(x => x.ID == ID).SingleOrDefault().Status;
            }
        }


        /// <summary>
        /// Author:Piyush Joshi.
        /// Methods to Get All DefectStatus Based
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DefectStatus> GetAllStatus()
        {
           return _defectStatusData.GetAll();
        }


        /// <summary>
        /// Author:Piyush Joshi.
        /// Methods to Get Name of Priority Based On ID
        /// </summary>
        /// <returns></returns>
        public string GetPriorityName(int? ID)
        {
            string data;

            if (ID == null || ID == 0)
            {
                return data = "Not Assigned";
            }
            else { 
            return GetAllPriority().Where(x => x.ID == ID).First().Priorityy;
        }
        }

        /// <summary>
        /// Author:Piyush Joshi.
        /// Methods to Get All Priorities Based
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Priority> GetAllPriority()
        {
            return _priorityData.GetAll();
        }
    }
}
