using MediatR;
using SkyQuery.Location.Application.Common.Interfaces;
using SkyQuery.Location.Domain.Entities;

namespace SkyQuery.Location.Application.Locations.Commands;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Guid>
{
    private readonly ILocationDbContext _context;

    public CreateLocationCommandHandler(ILocationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = new Domain.Entities.Location
        {
            Country = request.Country,
            City = request.City,
            Latitude = request.Latitude,
            Longitude = request.Longitude
        };

        _context.Locations.Add(location);
        await _context.SaveChangesAsync(cancellationToken);

        return location.Id;
    }
}
