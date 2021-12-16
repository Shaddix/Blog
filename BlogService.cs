using System.Linq;
using System.Text.Json;

namespace Blog
{
    class BlogService
    {
        private readonly MyDbContext _context;

        public BlogService(MyDbContext context)
        {
            _context = context;
        }

        public string GetAllPosts()
        {
            var data = _context.BlogPosts
                .Select(bp => bp.Title)
                .ToList();

            return JsonSerializer.Serialize(data);
        }

        public string GetCommentsNumberPerUser()
        {
            var data = _context.BlogComments
                .GroupBy(bc => bc.UserName)
                .Select(item => new 
                {
                    UserName = item.Key,
                    Count = item.Count(), 
                })
                .OrderByDescending(item => item.Count)
                .ToList();

            return JsonSerializer.Serialize(data);
        }

        public string GetPostsOrderedByLastCommentDate()
        {
            var data = _context.BlogPosts
                .Select(bp => new 
                {
                    bp.Title,
                    LastComment = bp.Comments.OrderBy(bc => bc.CreatedDate).LastOrDefault(), 
                })
                .OrderByDescending(item => item.LastComment.CreatedDate)
                .Select(item => new
                {
                    item.Title,
                    item.LastComment.CreatedDate,
                    item.LastComment.Text,
                })
                .ToList();

            return JsonSerializer.Serialize(data);
        }

        public string GetNumberOfLastCommentsLeftByUser()
        {
            var data = _context.BlogPosts
                .Select(bp => new
                {
                    LastComment = bp.Comments.OrderBy(bc => bc.CreatedDate).LastOrDefault(),
                })
                .AsEnumerable()
                .GroupBy(item => item.LastComment.UserName)
                .Select(item => new
                { 
                    UserName = item.Key,
                    Count = item.Count(),
                })
                .OrderByDescending(item => item.Count)
                .ToList();

            return JsonSerializer.Serialize(data);
        }
    }
}
