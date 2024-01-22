using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<Favorites> AddToFavoritesAsync(Favorites favorites, CancellationToken cancellationToken)
        {
            await db.Set<Favorites>().AddAsync(favorites, cancellationToken);
            return favorites;
        }

        public IQueryable<Car> GetCarsByDealer(int userId)
        {
            return db.Set<Car>().Where(m => m.CreatedBy == userId);
        }

        public IQueryable<Favorites> GetFavorites(int userId)
        {
            return db.Set<Favorites>().Where(m => m.UserId == userId);
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

        public IQueryable<Supply> GetSupplies(int carId)
        {
            var query = db.Set<CarSupply>().Where(m => m.CarId == carId);

            
            var sQuery = from cs in query
                         join s in db.Set<Supply>() on cs.SupplyId equals s.Id
                        select s;
            

            return sQuery;
        }

        public async Task RemoveFromFavorites(Favorites favorites, CancellationToken cancellationToken)
        {
            db.Set<Favorites>().Remove(favorites);
            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
