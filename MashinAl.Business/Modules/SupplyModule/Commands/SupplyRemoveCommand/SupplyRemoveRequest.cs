using MediatR;

namespace MashinAl.Business.Modules.SupplyModule.Commands.SupplyRemoveCommand
{
    public class SupplyRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
