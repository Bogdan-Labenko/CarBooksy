using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public record GetAllCarsQuery : IRequest<IQueryable<Car>>;

public class GetAllCarsHandler(ApplicationDbContext context) 
    : IRequestHandler<GetAllCarsQuery, IQueryable<Car>>
{
    public Task<IQueryable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        => Task.FromResult(context.Cars.AsQueryable());
}