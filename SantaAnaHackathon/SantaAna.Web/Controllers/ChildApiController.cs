using SantaAna.Web.Models.Requests;
using SantaAna.Web.Models.Response;
using SantaAna.Web.Models.ViewModels;
using SantaAna.Web.Services;
using System.Collections.Generic;
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
        [Route]
        [HttpGet]
        public HttpResponseMessage GetChilds()
        {
            ChildService childSvc = new ChildService();
            List<Child> childList = childSvc.GetChilds();
            return Request.CreateResponse(HttpStatusCode.OK, childList);
        } //GetChilds

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetChildById([FromUri] int id, ChildAddRequest payload)
        {
            ChildService childSvc = new ChildService();
            Child child = childSvc.GetChildById(id);
            return Request.CreateResponse(HttpStatusCode.OK, child);
        } //GetChildById

        // POST api/<controller>
        [Route]
        [HttpPost]
        public HttpResponseMessage CreateChild(ChildAddRequest payload)
        {
            ItemResponse<int> response = new ItemResponse<int>();
            ChildService childSvc = new ChildService();

            response.Item = childSvc.CreateChild(payload);
            return Request.CreateResponse(response);
        } //CreateChild

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        [Route("{id:int}")]
        [HttpDelete]
        public HttpResponseMessage DeleteChild([FromUri] int id)
        {
            ChildService childSvc = new ChildService();

            childSvc.DeleteChild(id);

            return Request.CreateResponse(HttpStatusCode.OK, id);
        } //DeleteChild
    }
}