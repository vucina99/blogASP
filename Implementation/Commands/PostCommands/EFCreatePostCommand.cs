using Application.Commands.PostCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Implementation.Commands.PostCommands
{
    public class EFCreatePostCommand : ICreatePostCommand
    {

        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreatePostValidator _validator;

        public EFCreatePostCommand(Context context, IMapper mapper, CreatePostValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Create new post";

        public void Execute(CreatePostDto request)
        {
            _validator.ValidateAndThrow(request);


            var post = _mapper.Map<Post>(request);

            var guid = Guid.NewGuid();

            var extension = Path.GetExtension(request.ImageFile.FileName);

            var newFileName = guid + "_" + request.ImageFile.FileName;

            var path = Path.Combine("wwwroot", "Images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.ImageFile.CopyTo(fileStream);
            }

            post.Image = newFileName;



            _context.Posts.Add(post);

            foreach (var IdTag in request.IdHashTag)
            {
                _context.PostHashTags.Add(new PostHashTag
                {
                    IdHashtag=IdTag,
                    Post=post
                    
                });
            }


            _context.SaveChanges();
        }
    }
}
