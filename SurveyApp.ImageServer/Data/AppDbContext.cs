using Microsoft.EntityFrameworkCore;
using SurveyApp.ImageServer.Data.Models;

namespace SurveyApp.ImageServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<AppImage> Images { get; set; }
    }
}
