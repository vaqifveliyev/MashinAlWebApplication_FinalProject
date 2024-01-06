using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MashinAl.Data.Repositories
{
    public class CarRepository : GeneralRepository<Car>, ICarRepository
    {

        public CarRepository(DbContext db) : base(db)
        {
        }

        public async Task<CarImage> AddCarImage(int carId, CarImage image, CancellationToken cancellationToken)
        {
            image.CarId = carId;
            await db.Set<CarImage>().AddAsync(image, cancellationToken);
            return image;

        }

        public async Task<CarSupply> AddCarSupply(int carId, CarSupply carSupply, CancellationToken cancellationToken)
        {
            carSupply.CarId = carId;
            await db.Set<CarSupply>().AddAsync(carSupply, cancellationToken);
            return carSupply;
        }

        public IQueryable<CarImage> GetImages(Expression<Func<CarImage, bool>> expression = null)
        {
            var query = db.Set<CarImage>().AsQueryable();

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            return query;
        }

        public IQueryable<CarSupply> GetSupplies(Expression<Func<CarSupply, bool>> expression = null)
        {
            var query = db.Set<CarSupply>().AsQueryable();
            if (expression is not null)
            {
                query = query.Where(expression);
            }

            return query;
        }
    }
}
