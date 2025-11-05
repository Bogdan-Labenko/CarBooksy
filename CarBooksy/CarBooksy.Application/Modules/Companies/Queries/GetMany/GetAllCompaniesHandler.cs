using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using MediatR;

namespace CarBooksy.Application.Modules.Companies.Queries.GetMany;

public class GetAllCompaniesQuery : IRequest<IQueryable<Company>>;

public class GetAllCompaniesHandler(ApplicationDbContext context) : IRequestHandler<GetAllCompaniesQuery, IQueryable<Company>>
{
    public Task<IQueryable<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        => Task.FromResult(context.Companies.AsQueryable());
}