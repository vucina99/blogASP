using Application;
using Application.Commands.CommentCommands;
using Application.DataTransfer;
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
    public class EFCreateCommentCommandd : ICreateCommentCommand
    {
        private readonly Context _context;
        private readonly CreateCommentValidator _validator;
        private readonly IApplicationActor _actor;

        public EFCreateCommentCommandd(Context context, CreateCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 8;

        public string Name => "Create Comment";

        public void Execute(CreateCommentDto request)
        {

            _validator.ValidateAndThrow(request);

            var comment = new Comment
            {
                idPost = request.idPost,
                Text = request.Text,
                idUser = _actor.Id
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
