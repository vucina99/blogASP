using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.HashTagQueries
{
    public interface IGetHashTagsQuery : IQuery<SearchHashTagDto, PagedResponse<HashTagDto>>
    {
    }
}
