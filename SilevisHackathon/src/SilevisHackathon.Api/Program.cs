using SilevisHackathon.Api.Extensions;
using SilevisHackathon.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(options =>
    options.SuppressAsyncSuffixInActionNames = false);

builder.Services.SetupAuthentication(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.SetupCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.SetupDbContext(builder.Configuration);

builder.Services.SetupMediatR();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("_localorigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await ApplicationDbContextSeeder.SeedAsync(applicationDbContext);
}


app.Run();
