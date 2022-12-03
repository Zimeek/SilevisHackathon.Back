using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetTeamByIdQuery
{
    public record Query(int? teamId) : IRequest<Team>;

    public class Handler : IRequestHandler<Query, Team>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Team> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.Teams
                .Include(t => t.People)
                .FirstOrDefaultAsync(t => t.Id == request.teamId);
        }
    }
}