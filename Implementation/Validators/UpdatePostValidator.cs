using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostValidator(Context context)
        {
            RuleFor(p => p.Id).NotEmpty()
                .WithMessage("You have to write some value for id");


            RuleFor(p => p.Title).NotEmpty()
                .WithMessage("You have to write post name");

            RuleFor(p => p.Title)
            .Must((dto, name) => !context.Posts.Any(p => p.Title == name && p.Id != dto.Id))
            .WithMessage(dto => $"Product with title {dto.Title} already exists.");


            RuleFor(x => x.Text).NotEmpty().WithMessage("You have to write Post Text.");


            RuleForEach(x => x.IdHashTag).Must(id => context.HashTags.Any(y => y.Id == id)).WithMessage((dto, id) => $"HashTag with id {id} does not exists");

        }
    }
}
