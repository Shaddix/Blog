using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new MyDbContext();
            context.Database.EnsureCreated();
            InitializeData(context);

            var data = context.BlogPosts.Select(x => x.Title).ToList();
        }

        private static void InitializeData(MyDbContext context)
        {
            context.BlogPosts.Add(new BlogPost("Post1")
            {
                Comments = new List<BlogComment>()
                {
                    new BlogComment("1", new DateTime(2020, 3, 4)),
                    new BlogComment("2", new DateTime(2020, 3, 1)),
                }
            });
            context.BlogPosts.Add(new BlogPost("Post2")
            {
                Comments = new List<BlogComment>()
                {
                    new BlogComment("3", new DateTime(2020, 3, 5)),
                    new BlogComment("4", new DateTime(2020, 3, 6)),
                }
            });
            context.BlogPosts.Add(new BlogPost("Post3")
            {
                Comments = new List<BlogComment>()
                {
                    new BlogComment("5", new DateTime(2020, 3, 7)),
                    new BlogComment("6", new DateTime(2020, 3, 9)),
                    new BlogComment("7", new DateTime(2020, 3, 8)),
                }
            });
            context.SaveChanges();
        }
    }
}