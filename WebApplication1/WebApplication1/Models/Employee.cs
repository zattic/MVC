using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public string Name { get; set; }

        public string Team { get; set; }

        public int Salary { get; set; }
    }
}