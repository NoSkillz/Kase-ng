using Kase_ng.DataAccess;
using Kase_ng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kase_ng.Controllers
{
    public class StepController : ApiController
    {
        KaseDbContext context;

        public StepController()
        {
            context = new KaseDbContext();
        }

        public IEnumerable<Step> Get(int Id)
        {
            var steps = context.Steps.Where(p => p.TestCase.Id == Id);

            return steps;
        }
    }
}
