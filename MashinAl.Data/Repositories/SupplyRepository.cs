using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class SupplyRepository : GeneralRepository<Supply>, ISupplyRepository
    {
        public SupplyRepository(DbContext db) : base(db)
        {
        }
    }
}
