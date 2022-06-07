using Application;
using Application.Commands.CommentCommands;
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

namespace Implementation.Commands.CommentCommands
{
    public class EFUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly Context _context;
        private readonly UpdateCommentValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public EFUpdateCommentCommand(Context context, UpdateCommentValidator validator, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 10;

        public string Name => "Update comment";

        public void Execute(UpdateCommentDto request)
        {
            var comment = _context.Comments.Find(request.Id);

            if (comment == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Comment));
            }
            if (comment.idUser != _actor.Id)
            {
                throw new Exception("You are not alowed to do this operation");
            }

            _validator.ValidateAndThrow(request);


            comment.Text = request.Text;
            _context.SaveChanges();
        }
    }
}
