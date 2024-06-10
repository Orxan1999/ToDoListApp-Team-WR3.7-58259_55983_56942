using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Dal
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}
