using SantaAna.Web.Models;
using SantaAna.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaAna.Web.Controllers
{
    public class ParentApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetParentById(int id)
        {
            ParentService parentSvc = new ParentService();
            List<Parent> parentList = parentSvc.GetParentByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, parentList);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}