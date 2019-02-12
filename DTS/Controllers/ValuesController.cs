using DATALayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DTS.Controllers
{
   // [Authorize]
    public class ValuesController : ApiController
    {
        protected readonly IUserService _userdata;
        public ValuesController(IUserService userdata)
        {
            this._userdata = userdata;
        }

        // GET api/values
        public IEnumerable<User> Get()
        {
            return _userdata.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
