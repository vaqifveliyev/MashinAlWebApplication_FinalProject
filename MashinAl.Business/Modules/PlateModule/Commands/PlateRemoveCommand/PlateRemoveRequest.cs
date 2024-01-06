using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateRemoveCommand
{
    public class PlateRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
