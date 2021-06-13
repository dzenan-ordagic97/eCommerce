using e_commerce.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly eCommerceContext context;

        public BuggyController(eCommerceContext context)
        {
            this.context = context;
        }

        [HttpGet("notFound")]
        public ActionResult GetNoFoundRequest()
        {
            var thing = context.Product.Find(42);
            if (thing == null)
                return NotFound(new ApiResponse(404));
            return Ok();
        }
        [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            var thing = context.Product.Find(42);
            var thingToReturn = thing.ToString();

            return Ok();
        }
        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
    }
}
