using ProductStore.Data;
using ProductStore.Models.Entities;

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
			var products = db.Product;
			return products;
		}
		public void Save(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
