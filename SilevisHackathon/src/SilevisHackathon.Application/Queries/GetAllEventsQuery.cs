using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetAllEventsQuery
{
    public record Query() : IRequest<ICollection<Event>>;

    public class Handler : IRequestHandler<Query, ICollection<Event>>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Event>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.Events
                .Include(e => e.Location)
                .Where(e => e.Date > DateTime.UtcNow)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}