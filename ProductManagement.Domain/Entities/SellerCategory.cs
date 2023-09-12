using ProductManagement.Domain.Bases;
using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
	public class SellerCategory : BaseEntity
	{
		public SellerCategory()
		{
			SubCategories = new HashSet<SellerSubCategory>();
		}

		public string Name { get; set; }

		public virtual ICollection<SellerSubCategory> SubCategories { get; set; }
	}
}
