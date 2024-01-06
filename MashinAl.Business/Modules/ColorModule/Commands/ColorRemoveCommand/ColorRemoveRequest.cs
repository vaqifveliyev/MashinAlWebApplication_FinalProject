using MediatR;

namespace MashinAl.Business.Modules.ColorModule.Commands.ColorRemoveCommand
{
    public class ColorRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
