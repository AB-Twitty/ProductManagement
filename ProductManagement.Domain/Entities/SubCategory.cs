﻿using ProductManagement.Domain.Bases;
using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
	public class SubCategory : BaseEntity
	{
		public SubCategory()
		{
			Products = new HashSet<Product>();
		}

		public string Name { get; set; }
		public string CategoryId { get; set; }
		public virtual Category Category { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}
