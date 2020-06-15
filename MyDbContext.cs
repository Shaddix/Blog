using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Forum
{
    public class MyDbContext : DbContext
    {
        private static SqliteConnection _connection;
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

        public MyDbContext() : base(new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlite(CreateInMemoryDatabase())
            .Options)
        {
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            return _connection;
        }

        public void Dispose() => _connection.Dispose();
    }
}