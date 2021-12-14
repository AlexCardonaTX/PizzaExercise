using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PizzaHut.PizzaApp.Data.Models;

namespace PizzaHut.PizzaApp.Data
{
    public class PizzaAppDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredient { get; set; }

        public PizzaAppDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("DBConnection"));
        }
    }
}
