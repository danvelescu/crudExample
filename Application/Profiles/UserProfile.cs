using crudExample.Domain.Models;
using AutoMapper;
using crudExample.Application.Users.Dto;
using crudExample.Application.Users.Commands;

namespace crudExample.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UserDto, User>();
        }
    }
}
