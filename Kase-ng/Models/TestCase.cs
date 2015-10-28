﻿using System;
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
        public DateTime LastRun { get; set; }
        public virtual TestCaseStatus TestCaseStatus { get; set; }
        //TODO: see if this works
    }
}