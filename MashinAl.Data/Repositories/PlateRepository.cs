using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class PlateRepository : GeneralRepository<Plate>, IPlateRepository
    {
        public PlateRepository(DbContext db) : base(db)
        {
        }
    }
}
