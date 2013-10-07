using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CabFareMeter.Models;
using CabFareMeter.BL;
using CabFareMeter.Contracts;

namespace CabFareMeter.Controllers
{
    public class FareController : ApiController
    {
        private readonly ICalculator<FareInput> _fareCalculator;

        public FareController(ICalculator<FareInput> fareCalculator)
        {
            _fareCalculator = fareCalculator;
        }

        // GET api/fare
        public HttpResponseMessage Get()
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "This controller does not implement GET"));
        }

        // GET api/fare/5
        public HttpResponseMessage Get(int id)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "This controller does not implement GET"));
        }

        // POST api/fare
        public HttpResponseMessage Post([FromBody]FareInput input)
        {
            if (input.MinutesAbove6mph <= 0)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Minutes should be more than 0"));
            }
            if (input.MilesBelow6mph <= 0)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Minutes should be more than 0"));
            }
            // No check for date and time as this method could be used for checking fare for an earlier or later time
            double fare = 0;
            try
            {
                fare = _fareCalculator.Calculate(input);
            }
            catch (Exception exc)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc));
            }
            return Request.CreateResponse(HttpStatusCode.OK, fare);
        }

        // PUT api/fare/5
        public void Put(int id, [FromBody]FareInput value)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "This controller does not implement PUT"));
        }

        // DELETE api/fare/5
        public void Delete(int id)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, "This controller does not implement DELETE"));
        }
    }
}
