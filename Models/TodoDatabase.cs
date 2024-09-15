using Microsoft.EntityFrameworkCore;

namespace TodoApp.Models
{
    public class TodoDatabase : DbContext
    {
        public DbSet<TodoApplication> Applications { get; set; }

        public TodoDatabase(DbContextOptions<TodoDatabase> options) :base(options) { }
    }
}
