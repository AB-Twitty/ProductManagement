using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Core.DTOs.Category
{
	public class CategoryCreateDto
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public bool IsActive { get; set; }
	}
}
