using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.AllowedUseCases, opt => opt.MapFrom(user => user.UserUseCases.Select(x => x.Id)));

            CreateMap<UserDto, User>();
        }
    }
}
