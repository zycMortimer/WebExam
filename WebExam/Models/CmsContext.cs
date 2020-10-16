using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebExam.Models
{
    public class CmsContext: DbContext
    {
        public CmsContext() : base("CmsDbConnection") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
    }
}