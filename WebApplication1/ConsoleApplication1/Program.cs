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
            //ALLQuery();
             NewMethod();
            //CreatNewPosts();
            //UpdatePosts();
            //DeletePosts();
            //AddPost();
            //QueryBlog();
            //createBlog();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

            private static void NewMethod()
        {
            //显示所有博客
            Console.WriteLine("所有博客：");
            QueryBlog();
            Console.WriteLine("-1-退出  -2-新增博客 -3-更改博客 -4-删除博客 -5-操作帖子 -6-查询博客");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                Environment.Exit(0);
                return;
            }
            else if (i == 2)
            {
                createBlog();
                QueryBlog();
                Console.Clear();
                NewMethod();

            }
            else if (i == 3)
            {
                Update();
                QueryBlog();
                Console.Clear();
                NewMethod();

            }
            else if (i == 4)
            {
                Delete();
                QueryBlog();
                Console.Clear();
                NewMethod();

            }
            else if (i == 5)
            {
                int blogid = GeBlogId();
                Console.WriteLine(blogid);
                //显示指定博客的帖子列表
                DisplayPosts(blogid);
                //清楚控制台信息
                Console.Clear();
                Console.WriteLine("-0-返回上一层 -1-新增帖子 -2-更改帖子 -3-删除帖子");
                int A = int.Parse(Console.ReadLine());
                if (A == 0)
                {
                    NewMethod();
                    Console.Clear();
                    Console.WriteLine("所有博客：");
                    QueryBlog();
                    Console.WriteLine("-1-退出 -2-新增博客 -3-更改博客 -4-删除博客 -5-操作帖子");
                    return;
                }
                else if (A == 1)
                {
                    CreatNewPosts(blogid);
                    DisplayPosts(blogid);
                    Console.WriteLine("新增成功");
                }
                else if (A == 2)
                {
                    UpdatePosts();
                    DisplayPosts(blogid);
                    Console.WriteLine("修改成功");

                }
                else if (A == 3)
                {
                    DeletePosts();
                    DisplayPosts(blogid);
                    Console.WriteLine("删除成功");
                }
            }
            else if (i == 6)
            {
                ALLQuery();
                QueryBlog();
                Console.Clear();
                NewMethod();

            }
            else
            {
                Console.WriteLine("无效字符");
                return;
            }
        }
          
            static int GeBlogId()
        {
            Console.WriteLine("请输入ID：");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
            //模糊查找
            static void ALLQuery()
        {
            Console.WriteLine("输入博客名称");
            string i = Console.ReadLine();
            BlogBusinessLayerss bbl = new BlogBusinessLayerss();
            List<Blog> blog = bbl.ALLQuery(i);
            foreach (var item in blog)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
            //新增博客
            static void createBlog()
        {
                Console.WriteLine("请输入一个博客名称");
                string name = Console.ReadLine();
                Blog blog = new Blog();
                blog.Name = name;
                BlogBusinessLayerss bbl = new BlogBusinessLayerss();
                bbl.Add(blog);

            }
            //查询全部博客
            static void QueryBlog()
        {

                BlogBusinessLayerss bbl = new BlogBusinessLayerss();
                var blogs = bbl.Query();
                foreach (var item in blogs)
                {
                    Console.WriteLine(item.BlogId + "" + item.Name);
                }
            }
            //修改博客
            static void Update()
        {
                Console.WriteLine("请输入id");
                int id = int.Parse(Console.ReadLine());
                BlogBusinessLayerss bbl = new BlogBusinessLayerss();
                Blog blog = bbl.Query(id);
                Console.WriteLine("请输入新名字");
                string name = Console.ReadLine();
                blog.Name = name;
                bbl.Update(blog);
            }
            //删除博客
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
                    Console.WriteLine("博客ID:{0}  ---  帖子题目：{1}  ---  帖子内容:{2}  ---帖子ID:{3}", item.BlogId, item.Title, item.Content, item.PostId);
                }
            }
            //新增帖子
            static void CreatNewPosts(int blogid)
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


