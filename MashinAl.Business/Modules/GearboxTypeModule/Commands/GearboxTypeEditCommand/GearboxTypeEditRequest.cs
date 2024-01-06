using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeEditCommand
{
    public class GearboxTypeEditRequest : IRequest<GearboxType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
