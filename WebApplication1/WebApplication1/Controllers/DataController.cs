using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataView()
        {
            string greeting;
            DateTime dt = DateTime.Now;
            int hour = dt.Hour;

            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            ViewData["greeting"] = greeting;

            Customer ct = new Customer();
            Employee emp = new Employee();

            ViewData["Customer"] = ct;
            ViewData["Employee"] = emp;

            emp.Name = "洛杉矶湖人队（Los Angeles Lakers）";
            //emp.Team = "NBA";
            emp.Salary = 1947;
            ct.CustomerName = "勒布朗";
            ct.FistName = "詹姆斯";
            ct.Address = "克利夫兰市阿克伦(美国俄亥俄州)";

            return View("DataView");
        }
    }
}