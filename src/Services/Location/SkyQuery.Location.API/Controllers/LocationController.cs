using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyQuery.Location.Application.Locations.Commands;
using SkyQuery.Location.Application.Locations.Queries;

namespace SkyQuery.Location.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetLocationByIdQuery(id));
        if (result is null)
            return NotFound();

        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllLocationsQuery());
        return Ok(result);
    }


}
