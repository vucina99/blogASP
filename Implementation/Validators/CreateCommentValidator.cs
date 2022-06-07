using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator(Context context)
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("You have to write comment")
                .MinimumLength(10).WithMessage("Comment has 10 character minimum");

            RuleFor(x => x.idPost).Must(x => context.Posts.Any(post => post.Id == x)).WithMessage("Post not exists");

        }
    }
}
