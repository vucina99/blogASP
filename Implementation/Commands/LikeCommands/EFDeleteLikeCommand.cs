using Application;
using Application.Commands.LikeCommands;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.LikeCommands
{
    public class EFDeleteLikeCommand : IDeleteLikeCommand
    {
        private readonly Context _context;
        private readonly IApplicationActor _actor;

        public EFDeleteLikeCommand(Context context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 7;

        public string Name => "Unlike post";

        public void Execute(int request)
        {


            var isLiked = _context.Likes.FirstOrDefault(x=>x.IdPost== request && x.idUser==_actor.Id);

            if (isLiked==null)
            {
                //throw new EntityNotFoundException(request, typeof(Like));
                throw new Exception("You are not alowed to do this operation or resource not found");
            }

            _context.Likes.Remove(isLiked);
            _context.SaveChanges();
        }
    }
}
