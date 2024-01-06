using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Queries.RegionGetByIdQuery
{
    public class RegionGetByIdRequest : IRequest<Region>
    {
        public int Id { get; set; }
    }
}
