using Microsoft.EntityFrameworkCore;

namespace ForumDocument.Entities.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<History> History { get; set; }
    }
}
