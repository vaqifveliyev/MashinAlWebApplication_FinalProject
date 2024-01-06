using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class MarkaRepository : GeneralRepository<Marka>, IMarkaRepository
    {
        public MarkaRepository(DbContext db) : base(db)
        {
        }
    }
}
