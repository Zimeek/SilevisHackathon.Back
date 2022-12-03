using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class RemoveTeamFromEventCommand
{
    public record Command(RemoveTeamFromEventHttpRequest request) : IRequest<Event>;

    public class Handler : IRequestHandler<Command, Event>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }        
        
        public async Task<Event> Handle(Command command, CancellationToken cancellationToken)
        {
            var eventt = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == command.request.EventId);
            eventt.Teams.RemoveAll(t => t.Id == command.request.TeamId);

            await _dbContext.SaveChangesAsync();

            return eventt;
        }
    }
}