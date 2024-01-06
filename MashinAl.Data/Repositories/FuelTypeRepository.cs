using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class FuelTypeRepository : GeneralRepository<FuelType>, IFuelTypeRepository
    {
        public FuelTypeRepository(DbContext db) : base(db)
        {
        }
    }
}
