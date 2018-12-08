﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public string GetString()
        {
            return "你好,MVC！";
        }
        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc";
            ct.Address = "def";
            return ct;
        }
        public ActionResult GetView()
        {
            //获取当前时间
            //获取当前小时数
            //根据
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

            Employee emp = new Employee();
            emp.Name = "李四";
            emp.Salary = 20002;
            ViewData["Employee"] = emp;
            return View("MyView");
        }
    }
}