using ProductStore.Models.Entities;

namespace ProductStore.Models
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAll();
		void Save(Product product);
	}
}
