using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetAllQuery
{
    public class GearboxTypeGetAllRequest : IRequest<IEnumerable<GearboxType>>
    {
    }
}
