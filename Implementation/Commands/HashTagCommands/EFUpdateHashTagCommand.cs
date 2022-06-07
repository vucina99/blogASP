using Application.Commands.HashTagCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.HashTagCommands
{
    public class EFUpdateHashTagCommand : IUpdateHashTagCommand
    {
        private readonly Context _context;
        private readonly UpdateHashTagValidator _validator;
        private readonly IMapper _mapper;

        public EFUpdateHashTagCommand(Context context, UpdateHashTagValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 21;

        public string Name => "Update HashTag";

        public void Execute(HashTagDto request)
        {
            var tag = _context.HashTags.Find(request.Id);

            if (tag == null)
            {
                throw new EntityNotFoundException(request.Id.Value, typeof(HashTag));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, tag);
            _context.SaveChanges();
        }
    }
}
