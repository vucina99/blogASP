using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateHashTagValidator : AbstractValidator<HashTagDto>
    {
        public UpdateHashTagValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You have to choose tag name");

            RuleFor(x => x.Name).Must((dto, name) => !context.HashTags.Any(y => y.Name == name && y.Id != dto.Id))
                 .WithMessage(dto => $"HashTag {dto.Name} already exists.");
        }
    }
}
