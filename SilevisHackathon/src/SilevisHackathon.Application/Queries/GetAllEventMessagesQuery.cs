using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetAllEventMessagesQuery
{
    public record Query(int eventId) : IRequest<ICollection<EventMessage>>;

    public class Handler : IRequestHandler<Query, ICollection<EventMessage>>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<EventMessage>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.EventMessages
                .Where(em => em.EventId == request.eventId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}