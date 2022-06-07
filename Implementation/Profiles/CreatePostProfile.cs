using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CreatePostProfile : Profile
    {
        public CreatePostProfile()
        {
            CreateMap<Post, CreatePostDto>();

            CreateMap<CreatePostDto, Post>();
        }
    }
}
