using MediatR;

namespace SkyQuery.Location.Application.Locations.Commands;

public class CreateLocationCommand : IRequest<Guid>
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
