using Application.Commands.HashTagCommands;
using Application.DataTransfer;
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
    public class EFCreateHashTagCommand : ICreateHashTagCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateHashTagValidator _validator;

        public EFCreateHashTagCommand(Context context, IMapper mapper, CreateHashTagValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Create new HashTag";

        public void Execute(CreateHashTagDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.HashTags.Add(_mapper.Map<HashTag>(request));
            _context.SaveChanges();
        }
    }
}
