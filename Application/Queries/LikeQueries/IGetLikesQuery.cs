using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.LikeQueries
{
    public interface IGetLikesQuery : IQuery<int, SumPerPost>
    {
    }
}
