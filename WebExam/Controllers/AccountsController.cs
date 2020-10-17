using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Data.Entity;
using WebExam.Models;

namespace WebExam.Controllers
{
    public class AccountsController : Controller
    {
        private CmsContext db = new CmsContext();

        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //防止跨網站的請求攻擊
        public ActionResult Login(Accounts model)
        {

            List<Models.Accounts> user = (from p in db.Accounts 
                                           where p.Account == model.Account && p.Password == model.Password
                                           select p).ToList();

            if (user.Count == 0)
            {
                return Content($"<h2>帳號密碼輸入錯誤</h2>", "text/html");
            }


            return Content($"<h2>登入成功</h2>", "text/html");

        }


    }
}