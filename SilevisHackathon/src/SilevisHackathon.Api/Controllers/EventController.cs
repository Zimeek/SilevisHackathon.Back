using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        
        [HttpGet("ByLocation/{id:int}")]
        public async Task<IActionResult> GetAllEventsByLocationIdAsync(int id)
        {
            var events = await _mediator.Send(new GetAllEventsByLocationIdQuery.Query(id));
            return Ok(events.Adapt<ICollection<EventDto>>());
        }

        [HttpGet("Upcoming")]
        public async Task<IActionResult> GetUpcomingEventsAsync()
        {
            var events = await _mediator.Send(new GetUpcomingEventsQuery.Query());
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
        
        [HttpGet("{id:int}/Teams")]
        public async Task<IActionResult> GetEventTeamsByEventId(int id)
        {
            var teams = await _mediator.Send(new GetEventTeamsByEventIdQuery.Query(id));
            
            return Ok(teams.Adapt<ICollection<TeamDto>>());
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync([FromBody]CreateEventHttpRequest request)
        {
            var newEvent = await _mediator.Send(new CreateEventCommand.Command(request));
            var actionName = nameof(GetEventByIdAsync);

            return CreatedAtAction(actionName, new { id = newEvent.Id }, newEvent.Adapt<EventDto>());
        }

        [Authorize]
        [HttpPost("AddTeam")]
        public async Task<IActionResult> AddTeamToEventAsync([FromBody]AddTeamToEventHttpRequest request)
        {
            var updatedEvent = await _mediator.Send(new AddTeamToEventCommand.Command(request));
            return Ok(updatedEvent.Adapt<EventDto>());
        }
        
        [Authorize]
        [HttpDelete("RemoveTeam")]
        public async Task<IActionResult> RemoveTeamFromEventAsync([FromBody]RemoveTeamFromEventHttpRequest request)
        {
            var updatedEvent = await _mediator.Send(new RemoveTeamFromEventCommand.Command(request));
            return Ok(updatedEvent.Adapt<EventDto>());
        }
    }
}
