using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DTS.Controllers
{
     [RoutePrefix("api/priority")]
    public class PriorityController : ApiController
    {
         
         private readonly IPriorityService _priorityData;

         public PriorityController(IPriorityService priorityData)
        {
            this._priorityData = priorityData;
        }
        /// <summary>
         /// Author:Jyoti Joshi.
         /// Created On:05-12-2016.
         /// Get all Status and id on Defect Entry form drop down
         /// </summary>
         [Route("GetPriority")]
         public IHttpActionResult Get()
         {
             return Ok(_priorityData.GetAll());
         }

    }
}
