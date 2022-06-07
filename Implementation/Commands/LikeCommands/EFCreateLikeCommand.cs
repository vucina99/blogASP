using Application;
using Application.Commands.LikeCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.LikeCommands
{
    public class EFCreateLikeCommand : ICreateLikeCommand
    {
        private readonly Context _context;
        private readonly IApplicationActor _actor;
        private readonly LikePostValidator _validator;

        public EFCreateLikeCommand(Context context, IApplicationActor actor, LikePostValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Like post";

        public void Execute(LikeDto request)
        {
            _validator.ValidateAndThrow(request);

            var like = new Like
            {
                idUser = _actor.Id,
                IdPost = request.IdPost
            };


            _context.Likes.Add(like);
            _context.SaveChanges();
        }
    }
}
