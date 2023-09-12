using System;

namespace ProductManagement.Domain.Bases
{
	public class BaseEntity
	{
		public string Id { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime LastUpdatedDate { get; set; }
	}
}
