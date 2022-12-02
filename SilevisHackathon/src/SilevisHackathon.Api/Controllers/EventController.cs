using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(events);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEventByIdAsync(int id)
        { 
            return Ok(await _mediator.Send(new GetEventByIdQuery.Query(id)));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync()
        {
            
            return Ok();
        }
        
    }
}
