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
    [RoutePrefix("api/ClientRequest")]
    public class ClientRequestController : ApiController
    {
        private readonly IClientRequest _iClientRequest;

        #region Constructor

        public ClientRequestController(IClientRequest iClientRequest)
        {
            this._iClientRequest = iClientRequest;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Author:Vipin.
        /// Created On:16-Feb-2019.
        /// API to get the list of all ClientRequest Users.
        /// </summary>
        /// <returns></returns>
        [Route("GetAllClientRequestUsers")]
        public IHttpActionResult Get()
        {
            return Ok(_iClientRequest.GetAll_ClientRequestUsers());
        }


        /// <summary>
        /// Author:Vipin.
        /// Created On:16-Feb-2019.
        /// API to save the Details of ClientRequestUser User.
        /// </summary>
        /// <param name="obj_ClientRequestUser"></param>


        [Route("AddClientRequestUser")]
        public void Post([FromBody]ClientRequest obj_ClientRequestUser)
        {
            _iClientRequest.Save_ClientRequestUser(obj_ClientRequestUser);
        }


        #endregion

    }
}


