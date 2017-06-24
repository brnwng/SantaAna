using SantaAna.Web.Models;
using SantaAna.Web.Models.Requests;
using SantaAna.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaAna.Web.Controllers
{
    [RoutePrefix("api/parents")]
    public class ParentApiController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [Route]
        public HttpResponseMessage GetParents()
        {
            ParentService parentSvc = new ParentService();
            List<Parent> parentList = parentSvc.GetParents();
            return Request.CreateResponse(HttpStatusCode.OK, parentList);
        }

        // POST api/<controller>
        [HttpPost]
        [Route]
        public HttpResponseMessage CreateParent(ParentAddRequest model)
        {
            ParentService parentSvc = new ParentService();
            int id = parentSvc.CreateParent(model);
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }


        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetParentById([FromUri] int id)
        {
   
            ParentService parentSvc = new ParentService();
            Parent row = parentSvc.GetParentById(id);
            return Request.CreateResponse(HttpStatusCode.OK, row);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteParent(int id)
        {
            ParentService parentSvc = new ParentService();
            parentSvc.DeleteParent(id);
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}