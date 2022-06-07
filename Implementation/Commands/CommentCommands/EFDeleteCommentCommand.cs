using Application;
using Application.Commands.CommentCommands;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.CommentCommands
{
    public class EFDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly Context _context;
        private readonly IApplicationActor _actor;

        public EFDeleteCommentCommand(Context context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 9;

        public string Name => "Delete comment";

        public void Execute(int request)
        {
            var comment = _context.Comments.FirstOrDefault(x=>x.Id==request && x.idUser==_actor.Id);

            if (comment == null)
            {
                throw new Exception("You are not alowed to do this operation or resource not found");
            }


            comment.IsActive = false;
            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
