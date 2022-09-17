using FluentValidation;

namespace Appeals.Application.Appeals.Commands.CreateAppeal
{
    public class CreateAppealCommandValidator : AbstractValidator<CreateAppealCommand>
    {
        public CreateAppealCommandValidator()
        {
            RuleFor(createAppealCommand =>
                createAppealCommand.Message).NotEmpty().MaximumLength(300);
            RuleFor(createAppealCommand =>
                createAppealCommand.Email).NotEmpty().MaximumLength(50);
            RuleFor(createAppealCommand =>
                createAppealCommand.PhoneNumber).NotEmpty().MaximumLength(11);
            RuleFor(createAppealCommand =>
                createAppealCommand.TypeName).NotEmpty();
        }
    }
}
