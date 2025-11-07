using MediatR;

namespace CarBooksy.Application.Modules.Companies.Queries.Get;

public record GetCompanyByIdQuery(Guid Id) : IRequest<GetCompanyByIdResponse?>;

internal class GetCompanyByIdHandler(IGetCompanyDataProvider provider) : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdResponse?>
{
    public Task<GetCompanyByIdResponse?> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        => provider.Get(request.Id, cancellationToken);
}