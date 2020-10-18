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
    }
}