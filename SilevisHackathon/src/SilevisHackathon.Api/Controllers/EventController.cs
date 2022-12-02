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
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllEventsAsync()
        {
            var events = await _mediator.Send(new GetAllEventsQuery.Query());
            return Ok(events.Adapt<ICollection<EventDto>>());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEventByIdAsync(int id)
        {
            var eventt = await _mediator.Send(new GetEventByIdQuery.Query(id));
            if (eventt is null)
            {
                return NotFound();
            }
            
            return Ok(eventt.Adapt<EventDto>());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync([FromBody]CreateEventHttpRequest request)
        {
            var newEvent = await _mediator.Send(new CreateEventCommand.Command(request));
            var actionName = nameof(GetEventByIdAsync);

            return CreatedAtAction(actionName, new { id = newEvent.Id }, newEvent.Adapt<EventDto>());
        }
    }
}
