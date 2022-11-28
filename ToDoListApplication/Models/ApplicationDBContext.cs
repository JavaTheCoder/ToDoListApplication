using Microsoft.EntityFrameworkCore;
using ToDoListDomainEntities;

namespace ToDoListApplication.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public DbSet<ToDoList> ToDoLists { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public ApplicationDBContext()
        {
            Database.EnsureCreated();
        }
    }
}
