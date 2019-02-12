using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DATALayer.Domain;
using ServiceLayer.Interfaces;

namespace DTS.Controllers
{
    public class JobController : ApiController
    {

        private readonly IJobService _iJobService;

        #region Constructor

        public JobController(IJobService iJobService)
        {
            this._iJobService = iJobService;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Author:Vipin.
        /// Created On:12-Feb-2019.
        /// API to get the list of all Sales Users.
        /// </summary>
        /// <returns></returns>
        [Route("GetAllJobUsers")]
        public IHttpActionResult Get()
        {
            return Ok(_iJobService.GetAll_JobUsers());
        }


        /// <summary>
        /// Author:Vipin.
        /// Created On:12-Feb-2019.
        /// API to save the Details of Sales User.
        /// </summary>
        /// <param name="obj_JobUser"></param>
        [Route("AddJobUser")]
        public void Post([FromBody]Job obj_JobUser)
        {
            _iJobService.Save_JobsUser(obj_JobUser);
        }


        #endregion

    }
}

