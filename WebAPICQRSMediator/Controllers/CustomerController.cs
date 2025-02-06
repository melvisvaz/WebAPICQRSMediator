using CQRS.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.Queries;

namespace WebAPICQRSMediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public CustomersController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            // Validation is automatically applied via FluentValidation
            var result =  await _mediator.Send(command);
            if (Convert.ToBoolean(result))
            {
                return CreatedAtAction(nameof(CreateCustomer), new { id = command.Id }, command);
            }

            return BadRequest("Failed to create customer.");
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var setting1 = _configuration["app:job"];
                var response = await _mediator.Send(new GetCustomersQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
