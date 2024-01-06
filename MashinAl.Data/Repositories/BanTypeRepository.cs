using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class BanTypeRepository : GeneralRepository<BanType>, IBanTypeRepository
    {
        public BanTypeRepository(DbContext db) : base(db)
        {
        }
    }
}
