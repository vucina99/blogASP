using Application.DataTransfer;
using Application.Queries;
using Application.Queries.CommentQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domen;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.CommentQueries
{
    public class EFGetCommentsQuery : IGetCommentsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetCommentsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 25;

        public string Name => "Search Comments";

        public PagedResponse<CommentsPostDto> Execute(SearchCommentDto search)
        {
            var comments = _context.Comments.Include(x => x.User).Include(x=>x.Post).AsQueryable();

            if (search.IdPost != 0)
            {
                comments = comments.Where(x => x.idPost == search.IdPost);
            }



            return comments.Paged<CommentsPostDto, Comment>(search, _mapper);
        }
    }
}
