using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Domain.Bases
{
	public class BaseEntity
	{
		[Key]
		public Guid Id { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime LastUpdatedDate { get; set; }
	}
}
