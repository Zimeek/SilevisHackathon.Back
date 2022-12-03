using System.IdentityModel.Tokens.Jwt;
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
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Event/{id:int}")]
        public async Task<IActionResult> GetAllEventMessagesAsync(int id)
        {
            var messages = await _mediator.Send(new GetAllEventMessagesQuery.Query(id));

            return Ok(messages.Adapt<ICollection<MessageDto>>());
        }

        [HttpPost("Event")]
        public async Task<IActionResult> CreateEventMessageAsync([FromBody]CreateEventMessageHttpRequest request)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var authorId = int.Parse(jwt.Claims.First(c => c.Type == "Id").Value);
            var message = await _mediator.Send(new CreateEventMessageCommand.Command(authorId, request));

            return Ok(message.Adapt<MessageDto>());
        }
        
        [HttpGet("Team/{id:int}")]
        public async Task<IActionResult> GetAllTeamMessagesAsync(int id)
        {
            var messages = await _mediator.Send(new GetAllTeamMessagesQuery.Query(id));

            return Ok(messages.Adapt<ICollection<MessageDto>>());
        }

        [HttpPost("Team")]
        public async Task<IActionResult> CreateTeamMessageAsync([FromBody]CreateTeamMessageHttpRequest request)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var authorId = int.Parse(jwt.Claims.First(c => c.Type == "Id").Value);
            var message = await _mediator.Send(new CreateTeamMessageCommand.Command(authorId, request));

            return Ok(message.Adapt<MessageDto>());
        }
        
        
    }
}
