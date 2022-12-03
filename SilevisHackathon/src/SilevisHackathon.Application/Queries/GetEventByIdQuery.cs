using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetEventByIdQuery
{
    public record Query(int eventId) : IRequest<Event>;

    public class Handler : IRequestHandler<Query, Event>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Event> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.Events
                .Include(e => e.Location)
                .FirstOrDefaultAsync(e => e.Id == request.eventId);
        }
    }
}