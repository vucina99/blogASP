using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class HashTagProfile : Profile
    {
        public HashTagProfile()
        {
            CreateMap<HashTag, HashTagDto>();

            CreateMap<HashTagDto, HashTag>();
        }
    }
}
