using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BussineLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            QueryBlog();
            Delete();
            QueryBlog();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        //增加--交互
        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBussinlayer bbl = new BlogBussinlayer();
            bbl.Add(blog);
        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBussinlayer bbl = new BlogBussinlayer();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.Write(item.BlogId + "");
                Console.WriteLine(item.Name);
            }
        }
        //更新某个博客
        static void Updata()
        {
            BlogBussinlayer bbl = new BlogBussinlayer();
            Console.Write("请输入一个博客id：");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            Console.Write("请输入新博客名：");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        //删除
        static void Delete()
        {
            BlogBussinlayer bbl = new BlogBussinlayer();
            Console.WriteLine("请输入一个博客ID");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
