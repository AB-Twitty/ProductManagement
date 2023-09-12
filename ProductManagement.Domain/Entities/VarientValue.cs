using ProductManagement.Domain.Bases;

namespace ProductManagement.Domain.Entities
{
	public class VarientValue : BaseEntity
	{
		public string Value { get; set; }
		public decimal IncreasedPrice { get; set; } = 0;
		public string VarientId { get; set; }
		public virtual Varient Varient { get; set; }
		public string ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}
