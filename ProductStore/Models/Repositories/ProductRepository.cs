using ProductStore.Data;
using ProductStore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models.ViewModels;

namespace ProductStore.Models.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private ApplicationDbContext db;
		public ProductRepository(ApplicationDbContext db)
		{
			this.db = db;
		}
		public IEnumerable<Product> GetAll()
		{
			var products = db.Product
				.Include(cat => cat.Category)
				.Include(man => man.Manufacturer)
				.ToList();
			return products;
		}
		public void Save(Product product)
		{
            db.Product.Add(product);

            db.SaveChanges();
        }
        public ProductsEditViewModel GetProductsEditViewModel()
        {
            var categories = db.Category.ToList();
            var manufacturers = db.Manufacturer.ToList();
            var productsEditViewModel = new ProductsEditViewModel
            {
                Categories = categories,
                Manufacturers = manufacturers
            };

            return productsEditViewModel;
        }
    }
}
