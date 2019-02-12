using DATALayer.Domain;
using DATALayer.Infrastucture;
using RepositryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class StatusService : IStatusService
    {
        private readonly IEntityBaseRepositry<DefectStatus> _statusData;  //interface type variable to get all project data
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IEntityBaseRepositry<DefectStatus> statusData, IUnitOfWork unitOfWork) 
        {
            this._statusData = statusData;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Author:Puja Mathpal.
        /// Created On: 5-12-2016
        /// Method to get Status Data.
        /// </summary>
        /// <param name="data"></param>
       
        //Method to get all data of Project table//
        public IEnumerable<DefectStatus> GetAll() 
        {

            return _statusData.GetAll().ToList();
        }


        
    }
}
