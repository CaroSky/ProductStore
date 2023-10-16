using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductStore.Controllers;
using ProductStore.Models;
using ProductStore.Models.Entities;
using ProductStore.Models.ViewModels;
using ProductStore.Models.Repositories;
using Moq;
using System.Collections.Generic;


namespace ProductUnitTest
{
	[TestClass]
	public class ProductControllerTest
	{
		private Mock<IProductRepository> _repository;
		[TestMethod]
		public void IndexReturnsAllProducts()
		{
			// Arrange
			_repository = new Mock<IProductRepository>();
			List<Product> fakeProducts = new List<Product>
			{
				new Product { Name = "Hammer", Price = 121.50m, Category = new Category { CategoryId = 1, Name = "Verktøy" } },
				new Product { Name = "Vinkelsliper", Price = 1520.00m, Category = new Category { CategoryId = 1, Name = "Verktøy" } },
				new Product { Name = "Melk", Price = 14.50m, Category = new Category { CategoryId = 2, Name = "Dagligvarer" } },
				new Product { Name = "Kjøttkaker", Price = 32.00m, Category = new Category { CategoryId = 2, Name = "Dagligvarer" } },
				new Product { Name = "Brød", Price = 25.50m, Category = new Category { CategoryId = 2, Name = "Dagligvarer" } }
            };
			_repository.Setup(x => x.GetAll()).Returns(fakeProducts);
			var controller = new ProductController(_repository.Object);

			// Act
			var result = (ViewResult)controller.Index();

			// Assert
			Assert.IsNotNull(result, "View Result is null");
			var products = result.ViewData.Model as List<Product>;
			Assert.IsNotNull(products, "Model is not of type List<Product>");
			CollectionAssert.AllItemsAreInstancesOfType(products, typeof(Product));
			Assert.AreEqual(5, products.Count, "Got the wrong number of products");
		}
		[TestMethod]
		public void IndexReturnsNotNullResult()
		{
			// Arrange
			var mockRepository = new Mock<IProductRepository>();
			var controller = new ProductController(mockRepository.Object);

			// Act
			var result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result, "View Result is null");
		}

        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        {
            // Arrange
            _repository = new Mock<IProductRepository>();
            var controller = new ProductController(_repository.Object);
            var newProductViewModel = new ProductsEditViewModel
            {
                Name = "New Product",
                Price = 50.00m,
                CategoryId = 1,  // Assign the appropriate CategoryId
                ManufacturerId = 1  // Assign the appropriate ManufacturerId
            };

            // Act
            controller.Create(newProductViewModel);

            // Assert
            _repository.Verify(repo => repo.Save(It.IsAny<Product>()), Times.Once);
        }
    }
}
