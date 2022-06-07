using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class UpdatePostProfile : Profile
    {
        public UpdatePostProfile()
        {

            CreateMap<Post, UpdatePostDto>();

            CreateMap<UpdatePostDto, Post>();
        }
    }
}
