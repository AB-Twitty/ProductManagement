using ProductManagement.Domain.Bases;
using System;

namespace ProductManagement.Domain.Entities
{
	public class Gallery : BaseEntity
	{
		public string ImagePath { get; set; }
		public string Placeholder { get; set; }
		public bool IsThumbnail { get; set; }
		public Guid ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}
