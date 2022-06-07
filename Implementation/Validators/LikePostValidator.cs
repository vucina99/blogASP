using Application;
using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class LikePostValidator : AbstractValidator<LikeDto>
    {
        public LikePostValidator(Context context,IApplicationActor actor)
        {

            RuleFor(x => x.IdPost).Must((dto, id) => !context.Likes.Any(like => like.idUser == actor.Id && like.IdPost == dto.IdPost))
                .WithMessage("You have already voted");
        }
    }
}
