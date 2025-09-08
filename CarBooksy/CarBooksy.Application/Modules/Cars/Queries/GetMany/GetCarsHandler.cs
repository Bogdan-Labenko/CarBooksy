using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public class GetCarsHandler(IGetCarsDataProvider provider) : IRequestHandler<GetCarsQuery, GetCarsResponse>
{
    public Task<GetCarsResponse> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        return provider.Get(request, cancellationToken);
    }
}