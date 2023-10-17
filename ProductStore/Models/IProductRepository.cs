using ProductStore.Models.Entities;
using ProductStore.Models.ViewModels;

namespace ProductStore.Models
{
	public interface IProductRepository
	{
        ProductsEditViewModel GetProductsEditViewModel();
        Product GetProductById(int? id);
        IEnumerable<Product> GetAll();
		void Save(Product product);
        void Edit(Product product);
        void Delete(int id);

    }
}
