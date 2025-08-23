using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Update;

public record UpdateCarCommand(Guid Id, CarDto CarDto) : IRequest<Guid?>;