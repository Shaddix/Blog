using System;

namespace Blog
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public BlogComment(string text, DateTime createdDate)
        {
            Text = text;
            CreatedDate = createdDate;
        }

        public DateTime CreatedDate { get; set; }

        public BlogPost BlogPost { get; set; }
        public int BlogPostId { get; set; }
    }
}