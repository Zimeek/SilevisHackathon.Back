using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class CreateTeamCommand
{
    public record Command(CreateTeamHttpRequest request) : IRequest<Team>;

    public class Handler : IRequestHandler<Command, Team>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Team> Handle(Command command, CancellationToken cancellationToken)
        {
            var team = new Team(command.request.Name, command.request.CaptainId);
            var captain = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == command.request.CaptainId);
            
            await _dbContext.Teams.AddAsync(team);
            team.CaptainId = command.request.CaptainId;
            team.People.Add(captain);
            await _dbContext.SaveChangesAsync();

            return team;
        }
    }
}