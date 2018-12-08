using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestView()
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
            Customer emp = new Customer();
            emp.CustomerName = "勒布朗";
            emp.FistName = "詹姆斯";
            emp.Address = "美国(Los Angeles)";          
            return View("TestView", emp);
        }
    }
}