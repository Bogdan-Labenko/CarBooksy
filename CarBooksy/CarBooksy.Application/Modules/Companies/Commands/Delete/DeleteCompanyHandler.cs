using MediatR;

namespace CarBooksy.Application.Modules.Companies.Commands.Delete;

public record DeleteCompanyCommand(Guid Id) : IRequest;

internal class DeleteCompanyHandler(IDeleteCompanyDataProvider provider) : IRequestHandler<DeleteCompanyCommand>
{
    public Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        => provider.Delete(request.Id, cancellationToken);
}