using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.Get;

public class GetCarByIdHandler(IGetCarDbProvider provider) : IRequestHandler<GetCarByIdQuery, CarDto?>
{
    public Task<CarDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        => provider.Get(request.Id, cancellationToken);
}