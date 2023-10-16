using Microsoft.AspNetCore.Mvc; 
using ProductStore.Models.Entities;
using ProductStore.Models;
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
			return View();
		}

		// POST: Product/Create
		[HttpPost]
		public ActionResult Create(Product product)
		{
			try
			{
				repository.Save(product);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

	}
}
