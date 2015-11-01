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
        public DateTime? LastRun { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
        
        //TODO: Workout areas and other upper levels
        //TODO: Will need DateAdded for some operations and maybe querying data to get a report
    }
}