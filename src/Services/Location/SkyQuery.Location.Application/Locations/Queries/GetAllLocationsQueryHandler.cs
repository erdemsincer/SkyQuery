using MediatR;
using Microsoft.EntityFrameworkCore;
using SkyQuery.Location.Application.Common.Interfaces;
using SkyQuery.Location.Domain.Entities;

namespace SkyQuery.Location.Application.Locations.Queries;

public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, List<Domain.Entities.Location>>
{
    private readonly ILocationDbContext _context;

    public GetAllLocationsQueryHandler(ILocationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.Location>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Locations.ToListAsync(cancellationToken);
    }
}
