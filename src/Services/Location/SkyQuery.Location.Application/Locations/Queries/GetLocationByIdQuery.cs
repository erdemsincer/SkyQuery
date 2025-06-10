using MediatR;
using SkyQuery.Location.Domain.Entities;

namespace SkyQuery.Location.Application.Locations.Queries;

public class GetLocationByIdQuery : IRequest<Domain.Entities.Location?>
{
    public Guid Id { get; set; }

    public GetLocationByIdQuery(Guid id)
    {
        Id = id;
    }
}
