using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Models;
using ConsoleApplication2.DataAccessLayer;

namespace ConsoleApplication2.BussinessLayer
{
    public class StuBussinessLayer
    {
        public void Add(ClassName CN)
        {
            using (var db = new StudentContext())
            {
                db.ClassNames.Add(CN);
                db.SaveChanges();
            }
        }
        public List<Student> Query()
        {
            using (var db = new StudentContext())
            {
                var query = from b in db.Students
                            orderby b.Name
                            select b;
                return query.ToList();
            }
        }
    }
}
