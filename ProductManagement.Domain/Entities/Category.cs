using ProductManagement.Domain.Bases;
using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
	public class Category : BaseEntity
	{
		public Category()
		{
			SubCategories = new HashSet<SubCategory>();
		}

		public string Name { get; set; }

		public virtual ICollection<SubCategory> SubCategories { get; set; }
	}
}
