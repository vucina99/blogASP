using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostValidator(Context context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("You have to write Post Title.")
                .Must(title=> !context.Posts.Any(x=>x.Title==title)).WithMessage(dto=>$"Post with {dto.Title} already exists");

            RuleFor(x => x.Text).NotEmpty().WithMessage("You have to write Post Text.");

            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("You have to choose image");

            RuleForEach(x => x.IdHashTag).Must(id => context.HashTags.Any(y => y.Id == id)).WithMessage((dto,id) => $"HashTag with id {id} does not exists");



        }
    }
}
