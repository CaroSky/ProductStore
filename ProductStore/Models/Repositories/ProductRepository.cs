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
        public Product GetProductById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return db.Product
                .Include(cat => cat.Category)
                .Include(man => man.Manufacturer)
                .FirstOrDefault(p => p.ProductId == id);
        }

        public void Edit(Product product)
        {

            db.Product.Update(product);

            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = GetProductById(id);

            if (product != null)
            {
                db.Product.Remove(product);
                db.SaveChanges();
            }
        }
        public ProductsEditViewModel GetProductsEditViewModel()
        {
            var categories = db.Category.ToList();
            var manufacturer = db.Manufacturer.ToList();
            var productsEditViewModel = new ProductsEditViewModel
            {
                Categories = categories,
                Manufacturer = manufacturer
            };

            return productsEditViewModel;
        }

    }
}
