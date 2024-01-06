using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Commands.SeatsRemoveCommand
{
    public class SeatsRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
