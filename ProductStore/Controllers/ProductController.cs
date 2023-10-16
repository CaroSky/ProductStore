using Microsoft.AspNetCore.Mvc; 
using ProductStore.Models.Entities;
using ProductStore.Models;
using ProductStore.Models.ViewModels;

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
            return View();
		}

		// POST: Product/Create
		[HttpPost]
		public ActionResult Create(ProductsEditViewModel product)
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
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

	}
}
