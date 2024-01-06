using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarRemoveCommand
{
    public class CarRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
