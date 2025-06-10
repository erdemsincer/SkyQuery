using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SkyQuery.Location.Application.Extensions;
using SkyQuery.Location.Infrastructure.Extensions;
using SkyQuery.Location.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// 👉 Connection string loglama (debug için)
Console.WriteLine("📡 LocationDb => " + builder.Configuration.GetConnectionString("LocationDb"));

// Add services to the container
builder.Services.AddApplication();     // ✅ MediatR + FluentValidation
builder.Services.AddInfrastructure(builder.Configuration); // ✅ EF + IOC

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation(); // ✅ Validator middleware

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Auth yok ama eklenecekse hazır
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// ✅ Migration otomatik çalıştır
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LocationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
