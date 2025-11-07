using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarBooksy.Application.Modules.Users.Queries.GetMany;

public record GetAllUsersQuery : IRequest<IQueryable<User>>;

internal class GetAllUsersHandler(ApplicationDbContext context) : IRequestHandler<GetAllUsersQuery, IQueryable<User>>
{
    public Task<IQueryable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        => Task.FromResult(context.Users.AsNoTracking().AsQueryable());
}