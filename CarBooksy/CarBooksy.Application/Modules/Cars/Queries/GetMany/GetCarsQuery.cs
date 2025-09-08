using CarBooksy.Shared.Models.Cars;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public class GetCarsQuery : IRequest<GetCarsResponse>
{
    public int Offset { get; init; } = 0;
    public int Limit { get; init; } = 10;

    public string? Make { get; init; }
    public string? Model { get; set; }
    public int? ProductionYear { get; set; }
    public BodyType? BodyType { get; set; }
    public CarStatus? Status { get; set; }
}