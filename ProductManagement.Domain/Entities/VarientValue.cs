using ProductManagement.Domain.Bases;
using System;

namespace ProductManagement.Domain.Entities
{
	public class VarientValue : BaseEntity
	{
		public string Value { get; set; }
		public decimal IncreasedPrice { get; set; } = 0;
		public Guid VarientId { get; set; }
		public virtual Varient Varient { get; set; }
		public Guid ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}
