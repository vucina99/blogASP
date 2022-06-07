using Application.DataTransfer;
using Application.Queries;
using Application.Queries.HashTagQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domen;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.HashTagQueries
{
    public class EFGetHashTagsQuery : IGetHashTagsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetHashTagsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 31;

        public string Name => "Search HashTags";

        public PagedResponse<HashTagDto> Execute(SearchHashTagDto search)
        {
            var hashTags = _context.HashTags.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
                hashTags = hashTags.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));

            return hashTags.Paged<HashTagDto, HashTag>(search, _mapper);
        }
    }
}
