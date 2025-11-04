using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public record GetAllCarsQuery : IRequest<IQueryable<Car>>;