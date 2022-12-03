using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class AddPersonToTeamCommand
{
    public record Command(AddPersonToTeamHttpRequest request) : IRequest<Team>;

    public class Handler : IRequestHandler<Command, Team>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Team> Handle(Command command, CancellationToken cancellationToken)
        {
            var person = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == command.request.PersonId, cancellationToken);
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == command.request.TeamId, cancellationToken);
            
            team.People.Add(person);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return team;
        }
    }
}