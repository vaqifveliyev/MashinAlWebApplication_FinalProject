using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeAddCommand
{
    public class GearboxTypeAddRequest : IRequest<GearboxType>
    {
        public string Name { get; set; }
    }
}
