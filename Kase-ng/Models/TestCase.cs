using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kase_ng.Models
{
    public class TestCase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // TODO: add to seed and remove from here
        public static List<TestCase> GetSample()
        {
            List<TestCase> tcs = new List<TestCase>()
            {
                new TestCase
                {
                    Id = 1,
                    Name = "Can view test cases",
                    Description = "Test to see if test cases can be viewed"
                },
                new TestCase
                {
                    Id = 2,
                    Name = "Can edit test cases",
                    Description = "Test cases for editing TCs"
                }
            };

            return tcs;
        }
    }
}