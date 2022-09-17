using System;
using FluentValidation;

namespace Appeals.Application.AppealTypes.Commands.DeleteAppealType
{
    public class DeleteAppealTypeCommandValidator : AbstractValidator<DeleteAppealTypeCommand>
    {
        public DeleteAppealTypeCommandValidator()
        {
            RuleFor(deleteAppealTypeCommand =>
                deleteAppealTypeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
