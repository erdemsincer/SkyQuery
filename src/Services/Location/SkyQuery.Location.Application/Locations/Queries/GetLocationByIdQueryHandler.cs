using MediatR;
using Microsoft.EntityFrameworkCore;
using SkyQuery.Location.Application.Common.Interfaces;
using SkyQuery.Location.Domain.Entities;

namespace SkyQuery.Location.Application.Locations.Queries;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Domain.Entities.Location?>
{
    private readonly ILocationDbContext _context;

    public GetLocationByIdQueryHandler(ILocationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Location?> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Locations
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
    }
}
