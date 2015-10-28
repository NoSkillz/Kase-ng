using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kase_ng.Models;
using Kase_ng.DataAccess;

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
    }
}
