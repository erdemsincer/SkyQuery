using MediatR;
using Microsoft.EntityFrameworkCore;
using SkyQuery.GeoData.Application.Common.Interfaces;
using SkyQuery.GeoData.Domain.Entities;

namespace SkyQuery.GeoData.Application.GeoDatas.Queries;

public class GetGeoDataByIdQueryHandler : IRequestHandler<GetGeoDataByIdQuery, Domain.Entities.GeoData?>
{
    private readonly IGeoDataDbContext _context;

    public GetGeoDataByIdQueryHandler(IGeoDataDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.GeoData?> Handle(GetGeoDataByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.GeoDatas.FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken);
    }
}
