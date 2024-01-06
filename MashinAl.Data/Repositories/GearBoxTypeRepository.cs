using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class GearBoxTypeRepository : GeneralRepository<GearboxType>, IGearBoxTypeRepository
    {
        public GearBoxTypeRepository(DbContext db) : base(db)
        {
        }
    }
}
