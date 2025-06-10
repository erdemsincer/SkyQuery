using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyQuery.GeoData.Application.GeoDatas.Commands;
using SkyQuery.GeoData.Application.GeoDatas.Queries;

namespace SkyQuery.GeoData.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeoDataController : ControllerBase
{
    private readonly IMediator _mediator;

    public GeoDataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGeoDataCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetGeoDataByIdQuery(id));
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
