using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebExam.Models;
using System.Data.Entity;

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //防止跨網站的請求攻擊
        public ActionResult Create([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] Employee emp)  //Creat=>負責處理Post的Action，Bind指定想要改變的欄位也防止over-posting攻擊
        {
            //用ModelState.IsValid判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                //通過驗證，將資料存到資料庫
                db.Employees.Add(emp);
                db.SaveChanges();
                //儲存完成後回到Employees的Index頁面
                return RedirectToAction("Index");
            }

            //若未通過驗證，返回Form，直到正確
            return View(emp);
        }

        public ActionResult Edit(int? Id)
        {
            //檢查是否有員工Id
            if (Id == null)
            {
                return Content("查無資料，請提供員工編號");
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

        [HttpPost]
        [ValidateAntiForgeryToken]  //防止跨網站的請求攻擊
        public ActionResult Edit([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] Employee emp)  //Endit=>負責處理Post的Action，Bind指定想要改變的欄位也防止over-posting攻擊
        {
            //用ModelState.IsValid判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                //將emp這個Entity狀態設為Modified,
                //當SaveChanges()執行時,會向SQL Server發出Update陳述式命令
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                //儲存完成後回到Employees的Index頁面
                return RedirectToAction("Index");
            }

            //若未通過驗證，返回Form，直到正確
            return View(emp);
        }

        public ActionResult Delete(int? Id)
        {
            //檢查是否有員工Id
            if (Id == null)
            {
                return Content("查無資料，請提供員工編號");
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

        [HttpPost]
        [ValidateAntiForgeryToken]  //防止跨網站的請求攻擊
        public ActionResult Delete(int Id)  //Endit=>負責處理Post的Action，Bind指定想要改變的欄位也防止over-posting攻擊
        {
            //以Id找尋Entity，然後刪除
            Employee emp = db.Employees.Find(Id);
           
            db.Employees.Remove(emp);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        //關閉db連線，並釋放資源，下此使用必須在new一個實體
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}