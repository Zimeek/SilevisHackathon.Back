using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public class GetUpcomingEventsQuery
{
    public record Query() : IRequest<ICollection<Event>>;

    public class Handler : IRequestHandler<GetAllEventsQuery.Query, ICollection<Event>>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Event>> Handle(GetAllEventsQuery.Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.Events
                .Include(e => e.Location)
                .Where(e => e.Date > DateTime.UtcNow)
                .OrderByDescending(e => e.Date)
                .Take(10)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}