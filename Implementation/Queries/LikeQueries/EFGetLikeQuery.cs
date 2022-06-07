using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.LikeQueries;
using AutoMapper;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.LikeQueries
{
    public class EFGetLikeQuery : IGetLikeQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetLikeQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 22;

        public string Name => "Get sum likes for post";

        public SumPerPost Execute(int search)
        {
            var post = _context.Posts.Find(search);


            if (post == null)
            {
                throw new EntityNotFoundException(search, typeof(Post));
            }

            var sumLikes = _context.Likes.Where(x => x.IdPost == search).Count();

            return new SumPerPost
            {
                SumLikes = sumLikes
            };
        }
    }
}
