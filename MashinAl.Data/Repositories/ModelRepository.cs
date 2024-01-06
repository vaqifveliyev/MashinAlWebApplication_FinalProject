using MashinAl.Infastructure.Commons.Concrates;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace MashinAl.Data.Repositories
{
    public class ModelRepository : GeneralRepository<Model>, IModelRepository
    {
        public ModelRepository(DbContext db) : base(db)
        {
        }
    }
}
