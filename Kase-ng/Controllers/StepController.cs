using Kase_ng.DataAccess;
using Kase_ng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Step Post(int id, [FromBody]string name)
        {
            //step.ItemStatus = context.ItemStatuses.Where(i => i.Name == "Not run").First();
            //step.TestCase = context.TestCases.Where(t => t.Id == testCaseId).First();

            var step = new Step
            {
                Name = name,
                ItemStatus = context.ItemStatuses.Where(i => i.Name == "Not run").First(),
                TestCase = context.TestCases.Where(t => t.Id == id).First()
            };

            context.Steps.Add(step);
            context.SaveChanges();

            var createdStep = context.Steps.Where(s => s.Name == step.Name && s.TestCase.Id == id).First();
            return createdStep;
        }
    }
}
