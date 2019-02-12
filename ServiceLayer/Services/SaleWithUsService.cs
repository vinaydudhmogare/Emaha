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
    public class SaleWithUsService: ISaleWithUsService
    {
        private readonly IEntityBaseRepositry<SalesUser> _salesData;  //interface type variable to get all Sales Users data
        private readonly IUnitOfWork _unitOfWork;

        public SaleWithUsService(IEntityBaseRepositry<SalesUser> salesData, IUnitOfWork unitOfWork)
        {
            this._salesData = salesData;
            this._unitOfWork = unitOfWork;
        }

        //Method to get all data of Sales Users table.
        public IEnumerable<SalesUser> GetAll_SalesUsers()
        {
            List<SalesUser> objA_SalesUser;

            try
            {
                objA_SalesUser = _salesData.GetAll().ToList();
            }
            catch (Exception ex)
            {
                objA_SalesUser = null;
            }

            return objA_SalesUser;
        }

        // Method to save the Details of Sales Users.
        public void Save_SalesUser(SalesUser obj_SalesUser)
        {
            try
            {
                if (obj_SalesUser != null)
                {
                    _salesData.Save(obj_SalesUser);
                    _unitOfWork.Commit();
                }

            }
            catch (Exception ex)
            {
            }
            
        }

    }
}
