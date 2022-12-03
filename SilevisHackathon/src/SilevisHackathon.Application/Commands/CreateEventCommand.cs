using MediatR;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class CreateEventCommand
{
    public record Command(CreateEventHttpRequest request) : IRequest<Event>;

    public class Handler : IRequestHandler<Command, Event>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Event> Handle(Command command, CancellationToken cancellationToken)
        {
            var newEvent = new Event(command.request.Name, command.request.LocationId, command.request.Date);
            
            await _dbContext.Events.AddAsync(newEvent, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newEvent;
        }
    }
}