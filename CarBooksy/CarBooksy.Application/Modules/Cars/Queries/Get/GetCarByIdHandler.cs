using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.Get;

public record GetCarByIdQuery(Guid Id) : IRequest<GetCarByIdQueryResponse>;

public class GetCarByIdHandler(IGetCarDataProvider provider) : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResponse?>
{
    public Task<GetCarByIdQueryResponse?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        => provider.Get(request.Id, cancellationToken);
}