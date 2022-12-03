using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SilevisHackathon.Domain.Models;
using SilevisHackathon.Application.Queries;
using SilevisHackathon.Application.HttpRequests;
using SilevisHackathon.Application.Commands;
using BC = BCrypt.Net;

namespace SilevisHackathon.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;
    
    public AuthController(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginHttpRequest request)
    {
        Person person = await _mediator.Send(new GetUserByEmailQuery.Query(request.Email));
        if (person is null) return Unauthorized();
        if (BC.BCrypt.Verify(request.Password, person.PasswordHash))
        {
            string token = GenerateJwtToken(person.Id, person.Email);
            return Ok(token);
        }
        return Unauthorized();
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreatePersonHttpRequest request){
        Person person = await _mediator.Send(new GetUserByEmailQuery.Query(request.Email));
        if (person is null)
        {
            Person newUser = await _mediator.Send(new CreatePersonCommand.Command(request));
            string token = GenerateJwtToken(newUser.Id, newUser.Email);
            return Ok(token);
        }
        return Conflict();
    }

    public string GenerateJwtToken(int id, string email)
    {
        var issuer = _configuration["jwt:issuer"];
        var audience = _configuration["jwt:audience"];
        var key = Encoding.ASCII.GetBytes(_configuration["jwt:key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {

                new Claim("Id", id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}