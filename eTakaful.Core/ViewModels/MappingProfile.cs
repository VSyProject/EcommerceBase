using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Dto;
using Ecommerce.Service.ViewModels;

namespace Ecommerce.Core.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingEntityToViewModel();
            MappingDtoToEntity();
        }

        private void MappingEntityToViewModel()
        {
            // case get data
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<User, UserDto>();
        }

        private void MappingDtoToEntity()
        {
            // case insert or update
            CreateMap<CategoryDto, Category>();
            CreateMap<UserDto, User>();
            CreateMap<RoleDto, Role>();
        }
    }
}