using SantaAna.Web.Models.Requests;
using SantaAna.Web.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaAna.Web.Controllers
{
    [RoutePrefix("api/child")]
    public class ChildApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route]
        [HttpPost]
        public HttpResponseMessage CreateChild(ChildAddRequest payload)
        {
            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = childSvc.CreateChild(payload);
            return Request.CreateResponse(response);
        } //CreateChild

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}