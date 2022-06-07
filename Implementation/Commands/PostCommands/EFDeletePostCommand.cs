using Application.Commands.PostCommands;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.PostCommands
{
    public class EFDeletePostCommand : IDeletePostCommand
    {
        private readonly Context _context;

        public EFDeletePostCommand(Context context)
        {
            _context = context;
        }

        public int Id => 17;

        public string Name => "Delete post";

        public void Execute(int request)
        {
            var post = _context.Posts.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(Post));
            }

            post.IsActive = false;
            post.IsDeleted = true;
            post.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
