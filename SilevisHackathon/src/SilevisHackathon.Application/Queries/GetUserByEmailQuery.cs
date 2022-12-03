using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetUserByEmailQuery
{
    public record Query(string email) : IRequest<Person>;

    public class Handler : IRequestHandler<GetUserByEmailQuery.Query, Person>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> Handle(GetUserByEmailQuery.Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.People.FirstOrDefaultAsync(e => e.Email == request.email);
        }
    }   
}