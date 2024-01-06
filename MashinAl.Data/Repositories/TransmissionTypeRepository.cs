using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Data.Repositories
{
    public class TransmissionTypeRepository : GeneralRepository<TransmissionType>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(DbContext db) : base(db)
        {
        }
    }
}
