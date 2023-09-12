using ProductManagement.Domain.Bases;
using System.Collections.Generic;

namespace ProductManagement.Domain.Entities
{
	public class Varient : BaseEntity
	{
		public string Name { get; set; }

		public virtual ICollection<VarientValue> VarientValues { get; set; }
	}
}
