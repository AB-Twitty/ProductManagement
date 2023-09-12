using ProductManagement.Domain.Bases;
using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
	public class Product : BaseEntity
	{
		public Product()
		{
			Galleries = new HashSet<Gallery>();
			Varients = new HashSet<VarientValue>();
		}

		public string Name { get; set; }
		public string SKU { get; set; }
		public decimal Price { get; set; }
		public long QuantityInStock { get; set; }
		public float? PercentageDiscount { get; set; }
		public string SellerCategoryId { get; set; }
		public virtual SellerSubCategory SellerCategory { get; set; }
		public string CategoryId { get; set; }
		public virtual SubCategory Category { get; set; }

		public virtual ICollection<Gallery> Galleries { get; set; }
		public virtual ICollection<VarientValue> Varients { get; set; }
	}
}
