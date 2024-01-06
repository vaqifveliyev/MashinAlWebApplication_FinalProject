using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class CarStatusRepository : GeneralRepository<CarStatus>, ICarStatusRepository
    {
        public CarStatusRepository(DbContext db) : base(db)
        {
        }
    }
}
