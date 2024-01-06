using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class ColorRepository : GeneralRepository<Color>, IColorRepository
    {
        public ColorRepository(DbContext db) : base(db)
        {

        }
    }
}
