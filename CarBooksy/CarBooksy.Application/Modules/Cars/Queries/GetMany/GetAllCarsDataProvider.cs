using System.Reflection;
using CarBooksy.Domain.Entities;
using CarBooksy.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace CarBooksy.Application.Modules.Cars.Queries.GetMany;

public interface IGetAllCarsDataProvider
{
    IQueryable<Car> Get();
}

public class GetAllAllCarsDataProvider(ApplicationDbContext _context) : IGetAllCarsDataProvider
{
    public IQueryable<Car> Get()
        => _context.Cars.AsQueryable();
}