using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateHashTagValidator : AbstractValidator<CreateHashTagDto>
    {
        public CreateHashTagValidator(Context context)
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("You have to choose HashTag Name")
                .Must(name=> !context.HashTags.Any(x => x.Name == name)).WithMessage(dto => $"HashTag with {dto.Name} already exists");
        }
    }
}
