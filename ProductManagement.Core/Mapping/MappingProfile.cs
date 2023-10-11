using AutoMapper;
using ProductManagement.Core.DTOs.Category;
using ProductManagement.Core.DTOs.User;
using ProductManagement.Domain.Entities;
using ProductManagement.Identity.Models;

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


			CreateMap<AppUser, CreateUserDto>().ReverseMap();
		}
	}
}
