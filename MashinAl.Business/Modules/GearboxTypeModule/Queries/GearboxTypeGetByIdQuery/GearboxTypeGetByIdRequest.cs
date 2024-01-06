using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetByIdQuery
{
    public class GearboxTypeGetByIdRequest : IRequest<GearboxType>
    {
        public int Id { get; set; }
    }
}
