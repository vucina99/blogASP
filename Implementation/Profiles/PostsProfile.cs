using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            CreateMap<Post, PostsDto>()
                   .ForMember(dto => dto.SumLikes, opt => opt.MapFrom(post => post.Likes.Count()))
                   .ForMember(dto => dto.SumComments, opt => opt.MapFrom(post => post.Comments.Count()));


            CreateMap<PostsDto, Post>();
        }
    }
}
