using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SkyQuery.GeoData.Application.Extensions;
using SkyQuery.GeoData.Infrastructure.Extensions;
using SkyQuery.GeoData.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Log connection
Console.WriteLine("📡 GeoDataDb => " + builder.Configuration.GetConnectionString("GeoDataDb"));

// Services
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

// Auto migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GeoDataDbContext>();
    db.Database.Migrate();
}

app.Run();
