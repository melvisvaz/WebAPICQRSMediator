using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CQRS.Handlers
{
    public class CreateCustomerCommand :  IRequest<bool> 
    {
        public int Id { get; set; }
        public int CustomerNumber { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
    }
}