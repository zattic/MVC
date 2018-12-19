using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApplication2.Models;

namespace ConsoleApplication2.DataAccessLayer
{
    class StudentContext:DbContext
    {
        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
