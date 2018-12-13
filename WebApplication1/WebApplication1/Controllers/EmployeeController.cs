using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModels empListModel = new EmployeeListViewModels();
            //获取将处理过的数据列表
            empListModel.EmployeeViewList = getEmpVmList();
            //获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }
        [NonAction]
        List<EmployeeViewModels> getEmpVmList()
        {
            //实例化员工信息
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBL.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModels>();
            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModels empVmObj = new EmployeeViewModels();
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "20";
                }
                listEmpVm.Add(empVmObj);
            }
            return listEmpVm;
        }
        [NonAction]

        string getGreeting()
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
            return greeting;
        }
        [NonAction]

        string getUserName()
        {
            return "Admin";
        }
    }
}













        