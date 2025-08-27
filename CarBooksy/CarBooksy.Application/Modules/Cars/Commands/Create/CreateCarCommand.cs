using CarBooksy.Shared.Models.Cars;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Create;

public class CreateCarCommand : CreateCarCommandBase, IRequest<Guid>
{
}