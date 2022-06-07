using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class SumLikesProfile : Profile
    {
        public SumLikesProfile()
        {
            CreateMap<Like, LikesSumDto>();


            CreateMap<LikesSumDto, Like>();
        }
    }
}
