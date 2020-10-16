using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace WebExam.Controllers
{
    public class RunProgramController : Controller
    {
        // GET: RunProgram
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Run()
        {
            

            if (!TempData.ContainsKey("Title"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempData.Keep();
            string title = TempData["Title"].ToString();
            string strHtml = SwitchProgram(title);

            return Content(strHtml, "text/html");
        }

        protected string SwitchProgram(string title)
        {
            string strHtml = "";

            switch (title)
            {
                case "印星星":
                    for (int i = 0; i < 5; i++)
                    {
                        strHtml += "<div>";
                        for (int j = 0; j <= i; j++)
                        {
                            strHtml += "*";
                        }
                        strHtml += "</div>";
                    }
                    break;
                default:
                    strHtml = "<h2>還沒寫出來</h2>";
                    break;
            }

            return strHtml;
        }
    }
}