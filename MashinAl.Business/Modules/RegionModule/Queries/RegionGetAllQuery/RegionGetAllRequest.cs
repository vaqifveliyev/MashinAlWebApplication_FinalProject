using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Queries.RegionGetAllQuery
{
    public class RegionGetAllRequest : IRequest<IEnumerable<Region>>
    {
    }
}
