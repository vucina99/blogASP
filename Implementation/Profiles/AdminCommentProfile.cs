using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class AdminCommentProfile : Profile
    {
        public AdminCommentProfile()
        {
            CreateMap<Comment, CommentsPostDto>()
                .ForMember(dto => dto.User, opt => opt.MapFrom(comment => comment.User.FirstName + " " + comment.User.LastName))
                .ForMember(dto => dto.PostTitle, opt => opt.MapFrom(comment => comment.Post.Title));


            CreateMap<CommentsPostDto, Comment>();
        }
    }
}
