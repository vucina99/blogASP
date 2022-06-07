using Application.DataTransfer;
using Application.Queries.LikeQueries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.LikeQueries
{
    public class EFGetLikesQuery : IGetLikesQuery
    {
        private readonly Context _context;

        public EFGetLikesQuery(Context context)
        {
            _context = context;
        }

        public int Id => 23;

        public string Name => "Get all likes";

        public SumPerPost Execute(int search)
        {
            var sum = _context.Likes.Count();

            return new SumPerPost
            {
                SumLikes = sum
            };
        }
    }
}
