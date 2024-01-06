using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetByIdQuery
{
    public class SupplyGetByIdRequest : IRequest<Supply>
    {
        public int Id { get; set; }
    }
}
