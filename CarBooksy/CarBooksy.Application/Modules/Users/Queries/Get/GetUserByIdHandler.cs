using CarBooksy.Application.Modules.Cars.Queries.Get;
using MediatR;

namespace CarBooksy.Application.Modules.Users.Queries.Get;

public record GetUserByIdQuery(Guid Id) : IRequest<GetUserByIdQueryResponse?>;

public class GetUserByIdHandler(IGetUserDataProvider provider) : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>
{
    public Task<GetUserByIdQueryResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        => provider.Get(request.Id, cancellationToken);
}