using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SilevisHackathon.Api.DTOs;
using SilevisHackathon.Application.Commands;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Application.Queries;

namespace SilevisHackathon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonByIdAsync(int id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery.Query(id));
            if (person is null)
            {
                return NotFound();
            }

            return Ok(person.Adapt<PersonDto>());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync([FromBody]CreatePersonHttpRequest request)
        {
            var person = await _mediator.Send(new CreatePersonCommand.Command(request));
            var actionName = nameof(GetPersonByIdAsync);

            return CreatedAtAction(actionName, new { id = person.Id }, person.Adapt<PersonDto>());

        }
    }
}
