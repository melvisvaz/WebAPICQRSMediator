using FluentValidation;

namespace CQRS.Handlers
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Length(5, 50).WithMessage("Full Name must be between 5 and 50 characters.");
        }

    }
}
