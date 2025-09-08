using CarBooksy.Shared.Models.Cars;
using MediatR;

namespace CarBooksy.Application.Modules.Cars.Commands.Update;

public class UpdateCarCommand : UpdateCarCommandBase, IRequest;