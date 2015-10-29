using Kase_ng.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Kase_ng.DataAccess
{
    public class KaseDbContext : IdentityDbContext<ApplicationUser>
    {
        public KaseDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //need to pass the modelbuilder to base because I'm inheriting from IdentityDbContext
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static KaseDbContext Create()
        {
            return new KaseDbContext();
        }

        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<ItemStatus> ItemStatuses { get; set; }
    }
}