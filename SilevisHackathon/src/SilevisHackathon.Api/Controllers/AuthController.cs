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
[Route("[controller]")]
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
        Person person = await _mediator.Send(new GetUserByNameOrEmailQuery.Query(request.Username, request.Username));
        if (person == null) return Unauthorized();
        if (BC.BCrypt.Verify(request.Password, person.PasswordHash))
        {
            var issuer = _configuration["jwt:issuer"];
            var audience = _configuration["jwt:audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                    new Claim(JwtRegisteredClaimNames.Email, request.Username),
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
            var stringToken = tokenHandler.WriteToken(token);
            return Ok(stringToken);
        }
        return Unauthorized();
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreatePersonHttpRequest request){
        Person person = await _mediator.Send(new GetUserByNameOrEmailQuery.Query(request.NickName, request.Email));
        if (person == null)
        {
            await _mediator.Send(new CreatePersonCommand.Command(request));
            return Ok();
        }
        return Conflict();
    }
}