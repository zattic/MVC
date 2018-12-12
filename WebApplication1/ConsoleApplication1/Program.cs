using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studenList = new List<Student>();

            Student st = new Student();
            st.Name = "丰田";
            st.Num = 180000;

            studenList.Add(st);

            st = new Student();
            st.Name = "bug";
            st.Num = 12;

            foreach(var item in studenList)
            {
                Console.WriteLine("Name:{0},Num:{1}", item.Name, item.Num);
            }
            Console.ReadKey();
        }
    }
}
