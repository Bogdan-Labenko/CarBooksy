using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public record GetAllCarsQuery : IRequest<IQueryable<Car>>;

internal class GetAllCarsHandler(ApplicationDbContext context) 
    : IRequestHandler<GetAllCarsQuery, IQueryable<Car>>
{
    public Task<IQueryable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        => Task.FromResult(context.Cars.AsNoTracking().AsQueryable());
}