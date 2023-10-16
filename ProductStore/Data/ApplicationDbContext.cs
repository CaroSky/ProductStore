using ProductStore.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models.Entities;

namespace ProductStore.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{ }
		public DbSet<Product> Product { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Manufacturer> Manufacturer { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>().ToTable("Product");
			// Seed Categories
			var categories = new List<Category>
			{
				new Category { CategoryId = 1, Name = "Verktøy" },
				new Category { CategoryId = 2, Name = "Dagligvarer" },
				new Category { CategoryId = 3, Name = "Kjøretøy" }
            };

			modelBuilder.Entity<Category>().HasData(categories);

			// Seed Manufacturers
			var manufacturers = new List<Manufacturer>
			{
				new Manufacturer { ManufacturerId = 1, Name = "Manufacturer 1" },
				new Manufacturer { ManufacturerId = 2, Name = "Manufacturer 2" }
            };

			modelBuilder.Entity<Manufacturer>().HasData(manufacturers);

			// Seed Products
			var products = new List<Product>
			{
                new Product
                {
                    ProductId = 1,
                    Name = "Hammer",
                    Price = 121.50m,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    Description = ""
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Vinkelsliper",
                    Price = 1520.00m,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    Description = ""
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Volvo XC90",
                    Price = 990000m,
                    CategoryId = 3,
                    ManufacturerId = 2,
                    Description = ""
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Volvo XC60",
                    Price = 620000m,
                    CategoryId = 3,
                    ManufacturerId = 2,
                    Description = ""
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Brød",
                    Price = 25.50m,
                    CategoryId = 2,
                    ManufacturerId = 1,
                    Description = ""
                },

                new Product
                {
                    ProductId = 6,
                    Name = "Produkt 1",
                    Price = 999995m,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    Description = "Bil"
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Produkt 2",
                    Price = 49.99m,
                    CategoryId = 2,
                    ManufacturerId = 1,
                    Description = ""
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Produkt 3",
                    Price = 199.99m,
                    CategoryId = 3,
                    ManufacturerId = 2,
                    Description = ""
                }
            };

            modelBuilder.Entity<Product>().HasData(products);
		}
	}
}