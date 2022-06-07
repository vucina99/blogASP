using Application.DataTransfer;
using AutoMapper;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class UpdateCommentProfile : Profile
    {
        public UpdateCommentProfile()
        {
            CreateMap<Comment, UpdateCommentDto>();



            CreateMap<UpdateCommentDto, Comment>();
        }
    }
}
