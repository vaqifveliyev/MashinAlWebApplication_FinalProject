using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeRemoveCommand
{
    public class GearboxTypeRemoveRequest : IRequest
    {
        public int Id { get; set; } 
    }
}
