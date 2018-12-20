using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample
{
   public class Program
    {
        static void Main(string[] args)
        {
            AddPost();
            //createBlog();
            //显示所有博客
            //QueryBlog();
            //Delete();
            //QueryBlog();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
            
        }


        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
            Console.WriteLine(blogId);
            //显示指定博客的帖子列表
            DisplatPosts(blogId);
            //根据指定到博客信息创建新帖子

            //新建帖子
            Post post = new Post();

            //填写帖子属性
            Console.WriteLine("请输入帖子标题");
            post.Title = Console.ReadLine();
            Console.WriteLine("请输入帖子内容");
            post.Content = Console.ReadLine();
            post.BlogId = blogId;
            //帖子通过数据库上下文新增    
            using(var db=new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }

            //显示指定博客的帖子列表
            DisplatPosts(blogId);
        }
        static int GetBlogId()
        {
            //提示用户输入博客ID
            Console.WriteLine("请输入一个帖子ID");
            //获取用户输入，并存入变量id
            int id = int.Parse(Console.ReadLine());
            //返回id
            return id;



        }
        static void DisplatPosts(int blogId)
        {
            Console.WriteLine(blogId+"的帖子列表");

            List<Post> list = null;
            //根据博客id获取博客
            using (var db=new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客到帖子
                list = blog.Posts;
            }

         
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
            foreach (var item in list)
            {
                Console.WriteLine(item.Blog.BlogId + "--" + item.Title);
            }
        }





        
        //增加--交互
        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            //接收一个用户输入
            string name = Console.ReadLine();
            //创建一个博客对象
            Blog blog = new Blog();
            //赋值名字
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.WriteLine(item.BlogId + "" + item.Name);
            }
        }
        //修改
        static void Update()
        {
            Console.WriteLine("请输入一个id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        //删除
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
