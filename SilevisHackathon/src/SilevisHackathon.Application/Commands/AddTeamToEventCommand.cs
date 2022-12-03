using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class AddTeamToEventCommand
{
    public record Command(AddTeamToEventHttpRequest request) : IRequest<Event>;

    public class Handler : IRequestHandler<Command, Event>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Event> Handle(Command command, CancellationToken cancellationToken)
        {
            var eventt = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == command.request.EventId, cancellationToken);
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == command.request.TeamId, cancellationToken);

            Guard.Against.Null(eventt, nameof(eventt));
            Guard.Against.Null(team, nameof(team));
            
            eventt.Teams.Add(team);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return eventt;
        }
    }
}