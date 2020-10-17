using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebExam.Models
{
    public class CmsContext: DbContext
    {
        /*
              Enable-Migrations                     啟動Migrations
              Add-Migration PostDataAnnotations     新增修正檔Add-Migration [檔名]
              Update-Database                       更新資料庫
        */

        public CmsContext() : base("CmsDbConnection") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}