using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class RegionRepository : GeneralRepository<Region>, IRegionRepository
    {
        public RegionRepository(DbContext db) : base(db)
        {
        }
    }
}
