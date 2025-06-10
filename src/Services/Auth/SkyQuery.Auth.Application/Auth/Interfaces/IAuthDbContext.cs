using Microsoft.EntityFrameworkCore;
using SkyQuery.Auth.Domain.Entities;
using System.Collections.Generic;

namespace SkyQuery.Auth.Application.Common.Interfaces;

public interface IAuthDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
