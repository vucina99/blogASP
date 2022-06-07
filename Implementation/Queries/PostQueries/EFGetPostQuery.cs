using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.PostQueries;
using AutoMapper;
using DataAccess;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.PostQueries
{
    public class EFGetPostQuery : IGetPostQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetPostQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "One post";

        public PostDto Execute(int search)
        {
            var post = _context.Posts
                .Include(x => x.PostHashTags).ThenInclude(x => x.HashTag)
                .Include(x => x.Comments).ThenInclude(x => x.User)
                .Include(x => x.Likes)
                .FirstOrDefault(x=>x.Id==search);





            if (post == null)
            {
                throw new EntityNotFoundException(search, typeof(Post));
            }


            return _mapper.Map<PostDto>(post);
        }
    }
}
