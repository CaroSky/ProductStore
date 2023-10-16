using ProductStore.Models.Entities;
using ProductStore.Models.ViewModels;

namespace ProductStore.Models
{
	public interface IProductRepository
	{
        ProductsEditViewModel GetProductsEditViewModel();
        IEnumerable<Product> GetAll();
		void Save(Product product);
	}
}
