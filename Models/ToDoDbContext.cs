using Microsoft.EntityFrameworkCore;
using To_doProject.Business.Entitites;

namespace To_doProject.DAL
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {
        }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<ToDoList> ToDoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
