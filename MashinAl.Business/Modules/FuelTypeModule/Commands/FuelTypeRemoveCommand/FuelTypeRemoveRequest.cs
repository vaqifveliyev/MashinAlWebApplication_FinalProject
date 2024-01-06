using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeRemoveCommand
{
    public class FuelTypeRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
