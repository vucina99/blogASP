using Application;
using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CommentProfile : Profile
    {


        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                //.ForMember(dto => dto.isAuthor, opt => opt.MapFrom(comment => comment.idUser == actor.Id ? 1 : 0))
                .ForMember(dto => dto.User, opt => opt.MapFrom(comment => comment.User.FirstName + " " + comment.User.LastName));


            CreateMap<CommentDto, Comment>();

        }

        
    //            .ForMember(dto => dto.Comments, opt => opt.MapFrom(post => post.Comments.Select(y => new CommentDto
    //            {
    //                Id = y.Id,
    //                idUser = y.idUser,
    //                idPost = y.idPost,
    //                Comment = y.Text,
    //                CreatedAt = y.CreatedAt,
    //                User = y.User.FirstName + " " + y.User.LastName
    //}).ToList()))
    }
}
