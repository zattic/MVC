using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "abc", "aaa", "bde", "aec", "awqqq" };
            var query1 = from x in names
                         where x.Contains("a")
                         select x;
            foreach(var item in query1)
            {
                Console.Write(item + "  ");
            }
            Console.ReadKey();

        }
    }
}
