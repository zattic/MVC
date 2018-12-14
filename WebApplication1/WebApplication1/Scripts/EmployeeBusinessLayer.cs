using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employee.ToList();

            //var list = new List<Employee>();
            //Employee emp = new Employee();
            //emp.Name = "狗子";
            //emp.Salary = 20000;
            //list.Add(emp);


            //emp = new Employee();
            //emp.Name = "喵咪";
            //emp.Salary = 20000;
            //list.Add(emp);

            //emp = new Employee();
            //emp.Name = "虎哥";
            //emp.Salary = 50000;
            //list.Add(emp);

            //return list;
        }
    }
}