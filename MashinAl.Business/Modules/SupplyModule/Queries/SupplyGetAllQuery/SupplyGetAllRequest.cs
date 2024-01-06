using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Queries.SupplyGetAllQuery
{
    public class SupplyGetAllRequest : IRequest<IEnumerable<Supply>>
    {
    }
}
