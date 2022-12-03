using MediatR;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class CreateTeamMessageCommand
{
    public record Command(int authorId, CreateTeamMessageHttpRequest request) : IRequest<TeamMessage>;

    public class Handler : IRequestHandler<Command, TeamMessage>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<TeamMessage> Handle(Command command, CancellationToken cancellationToken)
        {
            var message = new TeamMessage(command.request.Content, command.authorId, command.request.TeamId);
            
            await _dbContext.TeamMessages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message;
        }
    }
}