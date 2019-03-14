using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Controllers
{
    public class SharedBarsController : ApiController
    {
        /**
         * Return all the bars 
         **/
        [HttpGet]
        public HttpResponseMessage GetAllBars()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, bar.GetAllBarsAPI());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /**
         * Return the bar from id
         * id = the id of the requested bar
         **/
        [HttpGet]
        public HttpResponseMessage GetBar(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, bar.GetBarByIDAPI(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}