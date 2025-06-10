using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkyQuery.Auth.Application;
using SkyQuery.Auth.Infrastructure.Extensions;
using SkyQuery.Auth.Infrastructure.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Connection log (opsiyonel)
Console.WriteLine("🔍 Resolved AuthDb => " + builder.Configuration["ConnectionStrings:AuthDb"]);

builder.Services.AddApplication(); // MediatR + Validators
builder.Services.AddInfrastructure(builder.Configuration); // DB + JWT

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Auto-migrate
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

    var retries = 0;
    var maxRetries = 10;
    var delay = TimeSpan.FromSeconds(3);

    while (true)
    {
        try
        {
            dbContext.Database.Migrate();
            Console.WriteLine("✅ Database migration completed.");
            break;
        }
        catch (Exception ex)
        {
            retries++;
            Console.WriteLine($"❌ Migration failed (attempt {retries}): {ex.Message}");

            if (retries >= maxRetries)
                throw;

            Thread.Sleep(delay);
        }
    }
}


app.Run();
