using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;


namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {

                var list = dal.Employee.ToList();
                return list;
            }
        }
        //增加
        public void AddEmployee(Employee e)
        {
            using (var db = new SalesERPDAL())
            {
                db.Employee.Add(e);
                db.SaveChanges();
            }
        }
        //删除
        public void Delete(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employee.Find(id);
                db.Entry(emp).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        //修改
        public void UpdateEmployee(Employee emp)
        {
            using (var db = new SalesERPDAL())
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        //查询
        public Employee Query(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp=db.Employee.Find(id);
                return emp;
            }
        }
        //查询全部
        public IEnumerable<Employee> Search(string searchString)
        {
            using (var db = new SalesERPDAL())
            {
                return db.Employee.Where(e => e.Name.Contains(searchString)).ToList();

            }
        }
    }
}
