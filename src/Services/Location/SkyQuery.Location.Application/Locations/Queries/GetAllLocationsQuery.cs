using MediatR;
using SkyQuery.Location.Domain.Entities;

namespace SkyQuery.Location.Application.Locations.Queries;

public class GetAllLocationsQuery : IRequest<List<Domain.Entities.Location>> { }
