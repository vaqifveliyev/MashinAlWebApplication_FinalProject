using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarRejectCommand
{
    public class CarRejectRequest : IRequest
    {
        public int Id { get; set; }
        public string Reason { get; set; }
    }
}
