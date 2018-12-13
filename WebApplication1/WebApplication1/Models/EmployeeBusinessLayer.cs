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
        }
    }
}