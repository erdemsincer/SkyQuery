using MediatR;
using SkyQuery.GeoData.Application.Common.Interfaces;
using SkyQuery.GeoData.Domain.Entities;

namespace SkyQuery.GeoData.Application.GeoDatas.Commands;

public class CreateGeoDataCommandHandler : IRequestHandler<CreateGeoDataCommand, Guid>
{
    private readonly IGeoDataDbContext _context;

    public CreateGeoDataCommandHandler(IGeoDataDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateGeoDataCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.GeoData
        {
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Climate = request.Climate,
            Vegetation = request.Vegetation,
            Elevation = request.Elevation,
            Summary = request.Summary
        };

        _context.GeoDatas.Add(data);
        await _context.SaveChangesAsync(cancellationToken);
        return data.Id;
    }
}
