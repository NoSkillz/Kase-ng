using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Kase_ng.Models;
using Kase_ng.DataAccess;
using System.Web.Http.Results;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public TestCase Post([FromBody] string name)
        {
            if (name == null || name.Trim(' ') == string.Empty)
            {
                // TODO: See how to make this better
                throw new Exception();
            }

            var tc = new TestCase()
            {
                Name = name,
                LastRun = null,
                ItemStatus = context.ItemStatuses.Where(i => i.Name == "Not run").First(),
                DateCreated = DateTime.Now
            };

            context.TestCases.Add(tc);
            context.SaveChanges();

            return tc;
        }

        public TestCase Put(int id, [FromBody]TestCase tc)
        {
            if (tc.Name == null || tc.Name.Trim(' ') == string.Empty)
            {
                // TODO: See how to make this better
                throw new Exception();
            }

            context.TestCases.Attach(tc);
            context.Entry(tc).State = EntityState.Modified;
            context.SaveChanges();

            return tc;
        }
    }
}
