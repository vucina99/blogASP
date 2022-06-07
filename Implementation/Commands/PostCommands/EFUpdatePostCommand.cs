using Application.Commands.PostCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Implementation.Commands.PostCommands
{
    public class EFUpdatePostCommand : IUpdatePostCommand
    {
        private readonly Context _context;
        private readonly UpdatePostValidator _validator;
        private readonly IMapper _mapper;

        public EFUpdatePostCommand(Context context, UpdatePostValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Update Post";

        public void Execute(UpdatePostDto request)
        {
            var post = _context.Posts
                .Include(x => x.PostHashTags)
                .FirstOrDefault(x => x.Id == request.Id);



            if (post == null)
            {
                throw new EntityNotFoundException(request.Id.Value, typeof(Post));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, post);

            if (request.ImageFile != null)
            {
                var guid = Guid.NewGuid();

                var extension = Path.GetExtension(request.ImageFile.FileName);

                var newFileName = guid + "_" + request.ImageFile.FileName;

                var path = Path.Combine("wwwroot", "Images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    request.ImageFile.CopyTo(fileStream);
                }

                post.Image = newFileName;
            }

            post.PostHashTags.Where(x => !request.IdHashTag.Contains(x.IdHashtag)).ToList().ForEach(x => _context.PostHashTags.Remove(x));


            var exists = post.PostHashTags.Select(x => x.IdHashtag);
            _context.HashTags.Where(x => request.IdHashTag.Except(exists).Contains(x.Id)).ToList().ForEach(tag => _context.PostHashTags.Add(new PostHashTag
            {
                Post=post,
                HashTag=tag
            }));


            _context.SaveChanges();
        }
    }
}
