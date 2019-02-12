using DATALayer.Domain;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DTS.Controllers
{
    [RoutePrefix("api/SaleWithUs")]
    public class SaleWithUsController : ApiController
    {
        private readonly ISaleWithUsService _iSaleWithUsService;

        #region Constructor

        public SaleWithUsController(ISaleWithUsService iSaleWithUsService)
        {
            this._iSaleWithUsService = iSaleWithUsService;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Author:Prasanjit Day.
        /// Created On:10-Feb-2019.
        /// API to get the list of all Sales Users.
        /// </summary>
        /// <returns></returns>
        [Route("GetAllSalesUsers")]
        public IHttpActionResult Get()
        {
            return Ok(_iSaleWithUsService.GetAll_SalesUsers());
        }


        /// <summary>
        /// Author:Prasanjit Day.
        /// Created On:10-Feb-2019.
        /// API to save the Details of Sales User.
        /// </summary>
        /// <param name="obj_SalesUser"></param>
        [Route("AddSalesUser")]
        public void Post([FromBody]SalesUser obj_SalesUser)
        {
            _iSaleWithUsService.Save_SalesUser(obj_SalesUser);
        }


        #endregion

    }
}
