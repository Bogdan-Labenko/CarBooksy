using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Delete;

public record DeleteCarCommand(Guid Id) : IRequest<bool>;