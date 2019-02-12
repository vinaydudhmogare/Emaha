
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
     [RoutePrefix("api/Status")]
    public class StatusController : ApiController
    {

         private readonly IStatusService _statusData;

         public StatusController(IStatusService statusData)
        {
            this._statusData = statusData;
        }
        /// <summary>
         /// Author:Puja Mathpal.
         /// Created On:05-12-2016.
         /// Get all Status and id on Defect Entry form drop down
         /// </summary>
         [Route("GetStatus")]
         public IHttpActionResult Get()
         {
             return Ok(_statusData.GetAll());
         }

    }
}
