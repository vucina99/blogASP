using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.CommentQueries;
using AutoMapper;
using DataAccess;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.CommentQueries
{
    public class EFGetCommentQuery : IGetCommentQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetCommentQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 24;

        public string Name => "One comment";

        public CommentsPostDto Execute(int search)
        {
            var comment = _context.Comments.Include(x => x.User).Include(x => x.Post).FirstOrDefault(x=>x.Id==search);


            if (comment == null)
            {
                throw new EntityNotFoundException(search, typeof(Comment));
            }


            return _mapper.Map<CommentsPostDto>(comment);
        }
    }
}
