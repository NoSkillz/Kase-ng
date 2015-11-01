using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kase_ng.Models;
using Kase_ng.DataAccess;
using System.Web.Http.Results;

namespace Kase_ng.Controllers
{
    public class TestCaseController : ApiController
    {
        KaseDbContext context;

        public TestCaseController()
        {
            context = new KaseDbContext();
        }


        public IEnumerable<TestCase> Get()
        {
            var tcs = context.TestCases.Select(p => p);

            return tcs;
        }

        public TestCase Get(int id)
        {
            var tcs = context.TestCases.Select(p => p);

            var tc = tcs.FirstOrDefault(p => p.Id == id);

            return tc;
        }

        public IHttpActionResult Post(TestCase tc)
        {
            if (ModelState.IsValid)
            {
                tc.LastRun = null;
                context.TestCases.Add(tc);
                context.SaveChanges();
                return Ok();
            }

            return new InvalidModelStateResult(ModelState, this);
        }
    }
}
