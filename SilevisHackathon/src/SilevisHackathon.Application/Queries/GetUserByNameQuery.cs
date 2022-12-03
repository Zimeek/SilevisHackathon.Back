using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetUserByNameQuery
{
    public record Query(string name) : IRequest<Person>;

    public class Handler : IRequestHandler<GetUserByNameQuery.Query, Person>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> Handle(GetUserByNameQuery.Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.People.FirstOrDefaultAsync(e => e.NickName == request.name);
        }
    }   
}