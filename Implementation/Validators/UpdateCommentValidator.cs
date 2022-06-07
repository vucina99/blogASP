using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentValidator(Context context)
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("You have to write comment")
                .MinimumLength(10).WithMessage("Comment has 10 character minimum");


        }
    }
}
