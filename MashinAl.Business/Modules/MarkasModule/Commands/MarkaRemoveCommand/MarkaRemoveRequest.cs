using MediatR;

namespace MashinAl.Business.Modules.MarkasModule.Commands.MarkaRemoveCommand
{
    public class MarkaRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
