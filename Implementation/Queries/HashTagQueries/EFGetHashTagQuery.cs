using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries.HashTagQueries;
using AutoMapper;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.HashTagQueries
{
    public class EFGetHashTagQuery : IGetHashTagQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EFGetHashTagQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 30;

        public string Name => "One HashTag";

        public HashTagDto Execute(int search)
        {
            var hashTag = _context.HashTags.Find(search);

            if (hashTag == null)
            {
                throw new EntityNotFoundException(search, typeof(HashTag));
            }


            return _mapper.Map<HashTagDto>(hashTag);
        }
    }
}
