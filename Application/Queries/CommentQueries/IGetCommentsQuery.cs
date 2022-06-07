using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.CommentQueries
{
    public interface IGetCommentsQuery : IQuery<SearchCommentDto, PagedResponse<CommentsPostDto>>
    {
    }
}
