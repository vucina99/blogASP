using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<User, CreateUserDto>();

            CreateMap<CreateUserDto, User>();
        }
    }
}
