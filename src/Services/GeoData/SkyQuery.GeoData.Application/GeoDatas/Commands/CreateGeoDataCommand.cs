using MediatR;

namespace SkyQuery.GeoData.Application.GeoDatas.Commands;

public class CreateGeoDataCommand : IRequest<Guid>
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string Climate { get; set; } = string.Empty;
    public string Vegetation { get; set; } = string.Empty;
    public string Elevation { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty; // AI'dan gelen yorum
}
