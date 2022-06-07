using Application.Commands.HashTagCommands;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.HashTagCommands
{
    public class EFDeleteHashTagCommand : IDeleteHashTagCommand
    {
        private readonly Context _context;

        public EFDeleteHashTagCommand(Context context)
        {
            _context = context;
        }

        public int Id => 20;

        public string Name => "Delete HashTag";

        public void Execute(int request)
        {
            var post = _context.HashTags.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(HashTag));
            }

            post.IsActive = false;
            post.IsDeleted = true;
            post.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
