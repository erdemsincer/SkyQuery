namespace SkyQuery.GeoData.Domain.Entities;

public class GeoData
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Climate { get; set; } = string.Empty;
    public string Vegetation { get; set; } = string.Empty;
    public string Elevation { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty; // AI'dan gelen özet
}
