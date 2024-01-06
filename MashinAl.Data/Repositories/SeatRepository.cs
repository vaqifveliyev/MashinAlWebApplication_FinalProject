using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class SeatRepository : GeneralRepository<Seats>, ISeatRepository
    {
        public SeatRepository(DbContext db) : base(db)
        {
        }
    }
}
