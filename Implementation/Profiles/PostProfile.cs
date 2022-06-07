using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dto => dto.SumLikes, opt => opt.MapFrom(post => post.Likes.Count()))
                .ForMember(dto => dto.SumComments, opt => opt.MapFrom(post => post.Comments.Count()))
                .ForMember(dto=>dto.Likes,opt=>opt.MapFrom(post=>post.Likes.Select(y=> new UsersLikesDto
                {
                    IdUser=y.idUser,
                    UserName=y.User.FirstName+" "+y.User.LastName
                }).ToList()))
                .ForMember(dto => dto.Comments, opt => opt.MapFrom(post => post.Comments.Select(y => new CommentDto
                {
                    Id = y.Id,
                    idUser = y.idUser,
                    Text = y.Text,
                    CreatedAt = y.CreatedAt,
                    User = y.User.FirstName + " " + y.User.LastName
                }).ToList()))
                .ForMember(dto=>dto.PostHashTag,opt=> opt.MapFrom(post=>post.PostHashTags.Select(y=> new HashTagDto { 
                    Id=y.HashTag.Id,
                    Name=y.HashTag.Name
                }).ToList()));



            CreateMap<PostDto, Post>();
        }
    }
}
