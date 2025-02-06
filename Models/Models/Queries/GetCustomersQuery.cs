using MediatR;
using Models.Models;

namespace Models.Queries
{
    public record GetCustomersQuery() : IRequest<List<Customer>>;
}
