﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int ClassID { get; set; }
        public virtual ClassG Classes { get; set; }
    }
}
