using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class CityRepository : GeneralRepository<City>, ICityRepository
    {
        public CityRepository(DbContext db) : base(db)
        {
        }
    }
}
