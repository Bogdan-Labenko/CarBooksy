using MediatR;

namespace CarBooksy.Application.Modules.Cars.Queries.Get;

public record GetCarByIdQuery(Guid Id) : IRequest<GetCarByIdQueryResponse?>;