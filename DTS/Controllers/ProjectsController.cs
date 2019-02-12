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
    [RoutePrefix("api/Projects")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectService _projectData;
    
        public ProjectsController(IProjectService projectData)
        {
            this._projectData = projectData;
        }



        /// <summary>
        /// Author:Piyush Joshi.
        /// Get filtered data of project.
        /// Created on:29-Nov-2016,3:37PM
        /// </summary> 
        [Route("GetAllProject")]
        // GET api/projects/5
        public IHttpActionResult Get(string search, int page, int itemsPerPage = 5, string sortBy = " ", bool reverse = false)
        {

            return Ok(_projectData.GetDataList(search,page,itemsPerPage,sortBy));

        }

        // POST api/projects
        /// <summary>
        /// Author:Prassanjit Dey.
        /// Store the posted data of projects from front end.
        /// Created on:29-Nov-2016,11:49AM
        /// </summary>
        /// <param name="value"></param>
        [Route("AddProject")]
        public void Post([FromBody]Project value)
        {
            _projectData.Save(value);
        }


        /// <summary>
        /// Author:Prasanjit Day.
        /// Created On:29-Nov-2016.
        /// Get all project name and id on project entryform drop down
        /// </summary>
        [Route("GetParentProject")]
        public IHttpActionResult Get()
        {
            return Ok(_projectData.GetAll());
        }


        // PUT api/projects/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/projects/5
        public void Delete(int id)
        {
        }
    }
}
