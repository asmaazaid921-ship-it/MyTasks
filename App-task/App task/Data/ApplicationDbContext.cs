using Microsoft.EntityFrameworkCore;
using App_task.Models;

namespace App_task.Data
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}