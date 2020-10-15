using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Details(int? Id)
        {
            //檢查是否有員工存在
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //以Id 找尋員工資料
            Employee emp = db.Employees.Find(Id);

            //如果沒有找到員工，回傳HttpNotFound
            if (emp == null)
            {
                return HttpNotFound();
            }


            return View(emp);
        }
    }
}