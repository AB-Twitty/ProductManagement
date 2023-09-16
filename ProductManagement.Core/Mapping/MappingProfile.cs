using AutoMapper;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Core.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Category, CategoryListDto>();
			CreateMap<Category, CategoryCreateDto>().ReverseMap();
			CreateMap<Category, CategoryEditDto>().ReverseMap();
		}
	}
}
