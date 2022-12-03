using MediatR;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Infrastructure.Data;

namespace SilevisHackathon.Application.Commands;

public static class CreatePersonCommand
{
    public record Command(CreatePersonHttpRequest request) : IRequest<Person>;

    public class Handler : IRequestHandler<Command, Person>
    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Person> Handle(Command command, CancellationToken cancellationToken)
        {
            var newPerson = new Person(command.request.NickName, command.request.FirstName,
                command.request.LastName, command.request.Password, command.request.Email);

            await _dbContext.People.AddAsync(newPerson, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newPerson;
        }
    }
}