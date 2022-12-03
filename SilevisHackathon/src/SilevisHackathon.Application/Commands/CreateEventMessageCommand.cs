using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class CreateEventMessageCommand
{
    public record Command(int authorId, CreateEventMessageHttpRequest request) : IRequest<EventMessage>;

    public class Handler : IRequestHandler<Command, EventMessage>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<EventMessage> Handle(Command command, CancellationToken cancellationToken)
        {
            var message = new EventMessage(command.request.Content, command.authorId, command.request.EventId);
            
            await _dbContext.EventMessages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message;
        }
    }
}