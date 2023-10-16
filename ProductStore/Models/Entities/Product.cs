using System.ComponentModel.DataAnnotations.Schema;

namespace ProductStore.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
		[Column(TypeName = "decimal(8, 2)")]
        public decimal? Price { get; set; }
		//Navigational Properties
		public int ManufacturerId { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
