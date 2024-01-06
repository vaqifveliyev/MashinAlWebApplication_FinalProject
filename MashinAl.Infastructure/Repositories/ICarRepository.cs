using MashinAl.Infastructure.Commons.Abstracts;
using MashinAl.Infastructure.Entities;
using System.Linq.Expressions;

namespace MashinAl.Infastructure.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        IQueryable<CarImage> GetImages(Expression<Func<CarImage, bool>> expression = null);

        Task<CarImage> AddCarImage(int carId, CarImage image, CancellationToken cancellationToken);

        IQueryable<CarSupply> GetSupplies(Expression<Func<CarSupply, bool>> expression = null);
        Task<CarSupply> AddCarSupply(int carId, CarSupply carSupply, CancellationToken cancellationToken);

    }
}
