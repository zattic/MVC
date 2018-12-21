using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BlogBusinessLayer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreatNewPosts();
            //UpdatePosts();
            //DeletePosts();
            AddPost();
            //QueryBlog();
            //createBlog();

            Console.WriteLine("按任意键退出");
            Console.ReadKey();

        }
        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");         
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayerss bbl= new BlogBusinessLayerss();
            bbl.Add(blog);

        }
        static void QueryBlog()
        {
              
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.WriteLine(item.BlogId + "" + item.Name);
            }
        }

        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Blog blog= bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }

        static void Delete()
        {
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Console.WriteLine("请输入一个博客ID");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }

        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            Console.WriteLine("输入一个博客ID");
            int id = int.Parse(Console.ReadLine());

            //显示指定博客的帖子列表
            DisplayPosts(id);

            //根据指定到博客信息创建新帖子  
            Console.WriteLine("                              --新建帖子--");
            CreatNewPosts();

            //显示指定博客的帖子列表
            DisplayPosts(id);
        }
        static void DisplayPosts(int blogID)
        {
                       
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Blog blog = bbl.Query(blogID);

            List<Post> postList = bbl.pQuery(blogID);
            foreach (var item in postList)
            {
                Console.WriteLine("博客ID:{0}  ---  帖子题目：{1}  ---  帖子内容:{2}  ---帖子ID:{3}",item.BlogId, item.Title,item.Content,item.PostId);
            }

        }
        //新增帖子
        static void CreatNewPosts()
        {
            Console.WriteLine("请输入一个博客ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入一个帖子名称");
            string title = Console.ReadLine();
            Console.WriteLine("请输入一个帖子名称");
            string content = Console.ReadLine();

            Post post = new Post();
            post.BlogId = id;
            post.Title = title;
            post.Content = content;

            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            bbl.pAdd(post);
        }

        //static void PostByID(int blogID)
        //{
        //    Console.WriteLine("请输入一个帖子名称");
        //    string title = Console.ReadLine();
        //    Console.WriteLine("请输入一个帖子内容");
        //    string content = Console.ReadLine();

        //    Post post = new Post();
        //    post.BlogId = blogID;
        //    post.Title = title;
        //    post.Content = content;

        //    BlogBusinessLayerss bbl = new BlogBusinessLayerss();
        //    bbl.pAdd(post);
        //}



        //修改帖子
        static void UpdatePosts()
        {
            QueryBlog();


            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Console.WriteLine("请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayPosts(blogID);
            Console.WriteLine("请输入要修改的帖子ID");
            int postID = int.Parse(Console.ReadLine());
            Post post = bbl.postQuery(postID);
            Console.WriteLine("请输入新题目");
            string newTitle = Console.ReadLine();
            post.Title = newTitle;
            Console.WriteLine("请输入新内容");
            string newContent = Console.ReadLine();
            post.Content = newContent;
            bbl.pUpdate(post);
            DisplayPosts(blogID);


        }
        //删除帖子
        static void DeletePosts()
        {           
        
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            Console.WriteLine("请输入一个博客ID");
            int blogID = int.Parse(Console.ReadLine());
            DisplayPosts(blogID);
            Console.WriteLine("请输入要删除的帖子ID");
            int postID = int.Parse(Console.ReadLine());
            Post post = bbl.postQuery(postID);
            bbl.DeletePost(post);
            DisplayPosts(blogID);

        }
    }
}
