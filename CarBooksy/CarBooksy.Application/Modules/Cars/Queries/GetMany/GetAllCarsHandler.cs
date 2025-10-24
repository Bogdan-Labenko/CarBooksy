using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public class GetAllCarsHandler(IGetAllCarsDataProvider provider) : IRequestHandler<GetAllCarsQuery, IQueryable<Car>>
{
    public Task<IQueryable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        => Task.FromResult(provider.Get());

}