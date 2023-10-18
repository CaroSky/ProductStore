using Microsoft.AspNetCore.Mvc; 
using ProductStore.Models.Entities;
using ProductStore.Models;
using ProductStore.Models.ViewModels;
using ProductStore.Models.Repositories;


namespace ProductStore.Controllers
{
    public class ProductController : Controller
    {

		private IProductRepository repository;

		public ProductController(IProductRepository repository)
		{
			this.repository = repository;
		}

		public IActionResult Index()
        {
			IEnumerable<Product> products = repository.GetAll();

			return View(products);
		}

		// GET: Product/Create
		public ActionResult Create()
		{
            var product = repository.GetProductsEditViewModel();
            return View(product);
		}

		// POST: Product/Create
		[HttpPost]
		public ActionResult Create([Bind("Name,Description,Price,CategoryId,ManufacturerId")]ProductsEditViewModel product)
		{
			try
			{
                var newProduct = new Product
				{
					Name = product.Name,
					Description = product.Description,
					Price = product.Price,
					CategoryId = product.CategoryId,
					ManufacturerId = product.ManufacturerId
				};

				// Call the Save method in your repository to save the product
				repository.Save(newProduct);
                TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);
                return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
        // GET: Product/Edit/{id}
        public ActionResult Edit(int? id)
        {
            var product = repository.GetProductById(id);
            
            var categories = repository.GetAll().Select(p => p.Category).Distinct().ToList();
            var manufacturers = repository.GetAll().Select(p => p.Manufacturer).Distinct().ToList();

            var productEditViewModel = new ProductsEditViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ManufacturerId = product.ManufacturerId,
                Categories = categories,
                Manufacturer = manufacturers
            };

            return View(productEditViewModel);
        }
        // POST: Product/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, [Bind("ProductId,Name,Description,Price,CategoryId,ManufacturerId")] ProductsEditViewModel product)
        {
            {
                var existingProduct = repository.GetProductById(id);

                // Update the existing product with values from the view model
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ManufacturerId = product.ManufacturerId;

                // Save the changes
                repository.Edit(existingProduct);

                TempData["message"] = string.Format("{0} has been updated", product.Name);

                return RedirectToAction("Index");
            }
        }


        // POST: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = repository.GetProductById(id);

            repository.Delete(id);

            TempData["message"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
