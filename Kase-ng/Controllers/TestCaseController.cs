using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kase_ng.Models;

namespace Kase_ng.Controllers
{
    public class TestCaseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var tcs = TestCase.GetSample();

            return Ok(tcs);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tcs = TestCase.GetSample();

            var tc = tcs.FirstOrDefault(i => i.Id == id);
            return Ok(tc);
        }
    }
}
