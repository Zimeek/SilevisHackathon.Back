using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetPersonByIdQuery
{
    public record Query(int personId) : IRequest<Person>;

    public class Handler : IRequestHandler<Query, Person>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Person> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.People.FirstOrDefaultAsync(p => p.Id == request.personId);
        }
    }
}