using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            var list = new List<Employee>();

            Employee emp = new Employee();
            emp.Name = "狗子";
            emp.Salary = 10000;
            list.Add(emp);

            emp = new Employee();
            emp.Name = "猫咪";
            emp.Salary = 20000;
            list.Add(emp);

            emp = new Employee();
            emp.Name = "虎哥";
            emp.Salary = 30000;
            list.Add(emp);

            return list;
        }
    }
}