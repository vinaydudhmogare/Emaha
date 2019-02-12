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
    public class PriorityService:IPriorityService
    {
         private readonly IEntityBaseRepositry<Priority> _priorityData;  //interface type variable to get all project data
        private readonly IUnitOfWork _unitOfWork;

        public PriorityService(IEntityBaseRepositry<Priority> priorityData, IUnitOfWork unitOfWork) 
        {
            this._priorityData = priorityData;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Author:Jyoti Joshi
        /// Created On: 5-12-2016
        /// Method to get Priority Data.
        /// </summary>
        /// <param name="data"></param>
       
        //Method to get all data of Project table//
        public IEnumerable<Priority> GetAll() 
        {
            return _priorityData.GetAll().ToList();
        }

    }
}
