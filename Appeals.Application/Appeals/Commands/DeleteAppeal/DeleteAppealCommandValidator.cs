using System;
using FluentValidation;
namespace Appeals.Application.Appeals.Commands.DeleteAppeal
{
    public class DeleteAppealCommandValidator : AbstractValidator<DeleteAppealCommand>
    {
        public DeleteAppealCommandValidator()
        {
            RuleFor(deleteAppealCommand =>
                deleteAppealCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
