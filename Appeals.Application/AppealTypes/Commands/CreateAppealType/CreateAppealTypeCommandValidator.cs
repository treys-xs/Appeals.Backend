using FluentValidation;

namespace Appeals.Application.AppealTypes.Commands.CreateAppealType
{
    public class CreateAppealTypeCommandValidator : AbstractValidator<CreateAppealTypeCommand>
    {
        public CreateAppealTypeCommandValidator()
        {
            RuleFor(createAppelTypeCommand =>
                createAppelTypeCommand.TypeName).NotEmpty().MaximumLength(25);
        }
    }
}
