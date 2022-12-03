using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetEventTeamsByEventIdQuery
{
    public record Query(int eventId) : IRequest<ICollection<Team>>;
    
    public class Handler: IRequestHandler<Query, ICollection<Team>>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<ICollection<Team>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.Teams
                .Include(t => t.People)
                .Where(t => t.EventId == request.eventId)
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}