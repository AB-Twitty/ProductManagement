using ProductManagement.Domain.Bases;
using System;
using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
	public class SellerSubCategory : BaseEntity
	{
		public SellerSubCategory()
		{
			Products = new HashSet<Product>();
		}

		public string Name { get; set; }
		public Guid SellerCategoryId { get; set; }
		public virtual SellerCategory SellerCategory { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
