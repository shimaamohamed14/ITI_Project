using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
namespace ITI_Project.Context
{
    public class MyDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;DataBase=ITI_Project;trusted_connection=true;trustServerCertificate=true");
        }
    }
}
