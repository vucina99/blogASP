using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CreateHashTagProfile : Profile
    {
        public CreateHashTagProfile()
        {
            CreateMap<HashTag, CreateHashTagDto>();

            CreateMap<CreateHashTagDto, HashTag>();

        }
    }
}
