using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.UI.WebControls;

namespace WebExam.Controllers
{
    public class RunProgramController : Controller
    {
        // GET: RunProgram
        public ActionResult Index()
        {
            return View();
        }

        //從View/Posts/Detalis >> PostsController/redirectRunTitle
        public ActionResult Run()
        {
            if (!TempData.ContainsKey("Title"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TempData.Keep();
            string title = TempData["Title"].ToString();

            //string strHtml = SwitchProgram(title);

            //return Content(strHtml, "text/html");

            return SwitchProgram(title);
        }

        public ActionResult FtoC()
        {
            return View();
        }

        public ActionResult CircularArea()
        {
            return View();
        }

        public ActionResult FinalCode()
        {
            //ViewBag.FinalCodeError = "";
            ViewBag.FinalCodeMax = 100;
            ViewBag.FinalCodeMin = 1;
            Random R = new Random();
            ViewBag.FinalCodeAns = R.Next(1,100);

            return View();
        }

        protected ActionResult SwitchProgram(string title)
        {
            TempData["Title"] = title;
            string strHtml = "";
            switch (title)
            {
                case "印星星":
                    strHtml = printStar(strHtml);
                    return Content(strHtml, "text/html");
                case "華氏轉攝氏":
                    return RedirectToAction("FtoC");
                case "圓面積":
                    return RedirectToAction("CircularArea");
                case "終極密碼":
                    return RedirectToAction("FinalCode");
                default:
                    return Content("<h2>還沒寫出來</h2>", "text/html"); 
            }
        }
        protected string printStar(string strHtml)
        {
            for (int i = 0; i < 5; i++)
            {
                strHtml += "<div>";
                for (int j = 0; j <= i; j++)
                {
                    strHtml += "*";
                }
                strHtml += "</div>";
            }
            return strHtml;
        }

        [HttpPost]
        public ActionResult FtoC(string Celsius)
        {
            float f,c;

            if (!float.TryParse(Celsius, out c))
            {
                return Content("<h2>請輸入數字</h2>", "text/html");
            }

            f = c * 9 / 5 + 32;


            return Content("<h2>華氏：" + f.ToString() + "度</h>", "text/html");
        }

        [HttpPost]
        public ActionResult CircularArea(string Diameter)
        {
            double area, diameter;
            double PI = 3.14159;

            if (!double.TryParse(Diameter, out diameter))
            {
                return Content("<h2>請輸入數字</h2>", "text/html");
            }

            area = Math.Pow((diameter/2),2)*PI;


            return Content("<h2>圓面積：" + area.ToString() + "</h>", "text/html");
        }

        [HttpPost]
        public ActionResult FinalCode(string Code ,string Ans,string Max,string Min)
        {
            int ans, code,max,min;
            
            int.TryParse(Ans, out ans);
            int.TryParse(Max, out max);
            int.TryParse(Min, out min);
           
            if (!int.TryParse(Code, out code))
            {
                ViewBag.FinalCodeAns = ans.ToString();
                ViewBag.FinalCodeMax = max.ToString();
                ViewBag.FinalCodeMin = min.ToString();
                ViewBag.FinalCodeError = "請輸入數字";
                return View();
            }
            
            if (code > max || code < min)
            {
                ViewBag.FinalCodeAns = ans.ToString();
                ViewBag.FinalCodeMax = max.ToString();
                ViewBag.FinalCodeMin = min.ToString();
                ViewBag.FinalCodeError = "請輸入範圍內的數字";
                return View();
            }
            else if (code == ans)
            {
                return Content("<h2>終極密碼：" + ans.ToString() + "</h2><h3>你猜對了!!!</h3>", "text/html");
            }
            else if (code < ans)
            {
                min = code;
                ViewBag.FinalCodeAns = ans.ToString();
                ViewBag.FinalCodeMax = max.ToString();
                ViewBag.FinalCodeMin = min.ToString();
                return View();
            }
            else
            {
                max = code;
                ViewBag.FinalCodeAns = ans.ToString();
                ViewBag.FinalCodeMax = max.ToString();
                ViewBag.FinalCodeMin = min.ToString();
                return View();
            }
        }
    }
}