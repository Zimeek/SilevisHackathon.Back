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
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeamByIdAsync(int id)
        {
            var team = await _mediator.Send(new GetTeamByIdQuery.Query(id));
            if (team is null)
            {
                return NotFound();
            }

            return Ok(team.Adapt<TeamDto>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeamAsync([FromBody]CreateTeamHttpRequest request)
        {
            var newTeam = await _mediator.Send(new CreateTeamCommand.Command(request));
            var actionName = nameof(GetTeamByIdAsync);

            return CreatedAtAction(actionName, new { id = newTeam.Id }, newTeam.Adapt<TeamDto>());
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPersonToTeamAsync([FromBody] AddPersonToTeamHttpRequest request)
        {
            return Ok(await _mediator.Send(new AddPersonToTeamCommand.Command(request)));
        }
    }
}
