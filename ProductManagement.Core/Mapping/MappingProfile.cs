using AutoMapper;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Core.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Category, CategoryDto>();
			CreateMap<Category, CategoryListDto>();
		}
	}
}
