using MediatR;
using Microsoft.EntityFrameworkCore;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Queries;

public static class GetUserByNameOrEmailQuery
{
    public record Query(string name, string email) : IRequest<Person>;

    public class Handler : IRequestHandler<GetUserByNameOrEmailQuery.Query, Person>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> Handle(GetUserByNameOrEmailQuery.Query request, CancellationToken cancellationToken)
        {
            return await _dbContext.People.FirstOrDefaultAsync(e => e.NickName == request.name || e.Email == request.email);
        }
    }   
}