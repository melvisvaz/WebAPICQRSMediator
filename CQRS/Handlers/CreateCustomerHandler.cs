using FluentValidation;
using MediatR;
using Models.Models;

namespace CQRS.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {   
        private readonly IValidator<CreateCustomerCommand> _validator;

        public CreateCustomerCommandHandler(IValidator<CreateCustomerCommand> validator)
        {
            _validator = validator;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Create a new customer entity (you could map it to a domain model)
            var customer = new Customer
            {
                FullName = request.FullName,
                Address = request.Address,
                Id = request.Id,
                CustomerNumber = request.CustomerNumber
            };

            // Save customer to the repository
            await Task.Delay(2000); // Simulate some async work
            return true;
        }
    }
}
