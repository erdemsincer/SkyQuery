using FluentValidation;

namespace SkyQuery.GeoData.Application.GeoDatas.Commands;

public class CreateGeoDataCommandValidator : AbstractValidator<CreateGeoDataCommand>
{
    public CreateGeoDataCommandValidator()
    {
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        RuleFor(x => x.Climate).NotEmpty();
        RuleFor(x => x.Vegetation).NotEmpty();
        RuleFor(x => x.Elevation).NotEmpty();
    }
}
