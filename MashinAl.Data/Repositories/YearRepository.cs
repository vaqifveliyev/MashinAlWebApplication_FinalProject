using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class YearRepository : GeneralRepository<Year>, IYearRepository
    {
        public YearRepository(DbContext db) : base(db)
        {
        }
    }
}
