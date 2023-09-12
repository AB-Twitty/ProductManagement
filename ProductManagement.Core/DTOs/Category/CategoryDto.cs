using ProductManagement.Core.DTOs.Bases;

namespace ProductManagement.Core.DTOs.Category
{
	public class CategoryDto : BaseDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
	}
}
