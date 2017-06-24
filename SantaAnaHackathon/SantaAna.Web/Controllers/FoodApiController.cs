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
    [RoutePrefix("api/food")]
    public class FoodApiController : ApiController
    {
        [Route(""), HttpGet]
        public HttpResponseMessage GetFood()
        {
            FoodService foodSvc = new FoodService();
            List<Food> foodList = foodSvc.GetFood();
            return Request.CreateResponse(HttpStatusCode.OK, foodList);
        }

        [Route("{type}"), HttpGet]
        public HttpResponseMessage GetFoodByType([FromUri] string type)
        {
            FoodService foodSvc = new FoodService();
            List<Food> foodList = foodSvc.GetFoodByType(type);
            return Request.CreateResponse(HttpStatusCode.OK, foodList);
        }
    }
}
