using MediatR;
using SkyQuery.GeoData.Domain.Entities;

namespace SkyQuery.GeoData.Application.GeoDatas.Queries;

public class GetGeoDataByIdQuery : IRequest<Domain.Entities.GeoData?>
{
    public Guid Id { get; set; }

    public GetGeoDataByIdQuery(Guid id)
    {
        Id = id;
    }
}
