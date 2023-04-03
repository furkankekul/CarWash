using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CarWashesDbContext:DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee>Employees { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeDiscount> RecipeDiscounts { get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=CarWashesDb;Uid=root;Pwd=2909;", ServerVersion.AutoDetect("Server=localhost;Database=CarWashesDb;Uid=root;Pwd=2909;"), p => p.CommandTimeout(600));
        }

       
    }
}
