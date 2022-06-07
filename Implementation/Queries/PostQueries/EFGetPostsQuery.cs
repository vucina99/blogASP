using Application.DataTransfer;
using Application.Queries;
using Application.Queries.PostQueries;
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

namespace Implementation.Queries.PostQueries
{
    public class EFGetPostsQuery : IGetPostsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetPostsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Search posts";

        public PagedResponse<PostsDto> Execute(SearchPostDto search)
        {
            var posts = _context.Posts
                .Include(x => x.PostHashTags).ThenInclude(x => x.HashTag)
                .Include(x => x.Comments).ThenInclude(x => x.User)
                .Include(x => x.Likes)
                .AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                posts = posts.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                                    x.PostHashTags.Any(y => y.HashTag.Name.ToLower().Contains(search.Keyword.ToLower())));
            }
            if (search.IdHashTag.Count() > 0)
            {
                posts = posts.Where(x => x.PostHashTags.Any(y => search.IdHashTag.Contains(y.IdHashtag)));
            }
            if (search.MaxLike.HasValue)
            {
                posts = posts.Where(x => x.Likes.Count(y => y.IdPost == x.Id) <= search.MaxLike);
            }
            if (search.MinLike.HasValue)
            {
                posts = posts.Where(x => x.Likes.Count(y => y.IdPost == x.Id) >= search.MinLike);
            }
            if (search.dateFrom.HasValue)
            {
                posts = posts.Where(x => x.CreatedAt > search.dateFrom);
            }
            if (search.dateTo.HasValue)
            {
                posts = posts.Where(x => x.CreatedAt < search.dateTo);
            }

            return posts.Paged<PostsDto, Post>(search, _mapper);
        }
    }
}
