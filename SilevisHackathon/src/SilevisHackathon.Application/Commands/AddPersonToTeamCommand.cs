using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;
using Ardalis.GuardClauses;

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
            var team = await _dbContext.Teams
                .Include(t => t.People)
                .FirstOrDefaultAsync(t => t.Id == command.request.TeamId, cancellationToken);

            Guard.Against.Null(person, nameof(person));
            Guard.Against.Null(team, nameof(team));

            if (!team.People.Any(p => p.Id == person.Id))
            {
                team.People.Add(person);    
            }
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return team;
        }
    }
}