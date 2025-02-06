using MediatR;
using Models.Models;
using Models.Queries;

namespace CQRS.Handlers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        public Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var list = new List<Customer>();
            list.Add(new Customer() { Id = 1, FullName = "Jason" });
            return Task.FromResult(list);
        }
    }
}
