using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BusinessLayer
{
    public class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            //设置上下文生存期
            using (var db=new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using (var db=new BloggingContext())
            {
                
                var query = from b in db.Blogs
                         orderby b.Name
                       select b;
                return query.ToList();
            }
        }
        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        //修改
        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(blog).State = EntityState.Modified;
                //保存状态
                db.SaveChanges();
            }
        }
        //删除
        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(blog).State = EntityState.Deleted;
                //保存状态
                db.SaveChanges();
            }
        }


    }
}
