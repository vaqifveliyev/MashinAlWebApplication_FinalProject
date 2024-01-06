using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarPublishCommand
{
    public class CarPublishRequest : IRequest
    {
        public int Id { get; set; }
    }
}
