using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetAllTeamMessagesQuery
{
    public record Query(int teamId) : IRequest<ICollection<TeamMessage>>;

    public class Handler : IRequestHandler<Query, ICollection<TeamMessage>>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<TeamMessage>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.TeamMessages
                .Where(em => em.TeamId == request.teamId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}