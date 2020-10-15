using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExam.Models;

namespace WebExam.Controllers
{
    public class EmployeesController : Controller
    {
        private CmsContext db = new CmsContext();

        // GET: Employees
        public ActionResult Index()
        {
            //從資料庫讀取資料，建立model
            var emps = db.Employees.ToList();

            return View(emps);
        }
    }
}