using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using ToDoAPI.Models;

namespace ToDoAPI.AppDataContext{
    //TodoDbContext class inherits from DbContext
    public class TodoDbContext : DbContext
    {
        //DbSettings field to store connection string
        private readonly DbSettings _dbsettings;

        //constructor to inject the DbSettings model
        public TodoDbContext(IOptions<DbSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;
        }

        //DbSet property to represent the Todo table
        public DbSet<Todo> Todos { get; set;}

        //configure the database provider and connection str
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbsettings.ConnectionString);
        }

        //configure model for Todo entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
            .ToTable("TodoAPI")
            .HasKey(x => x.Id);
        }
    }
}