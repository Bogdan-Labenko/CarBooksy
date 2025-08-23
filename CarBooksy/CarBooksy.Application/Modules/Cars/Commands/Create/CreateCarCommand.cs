using CarBooksy.Domain.Entities;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;

public record CreateCarCommand(string make, string model, int year, string vin, string plate, BodyType bodyType, CarStatus status)
    : IRequest<Guid>;