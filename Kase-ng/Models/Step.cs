using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kase_ng.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
        public virtual TestCase TestCase { get; set; }
    }
}