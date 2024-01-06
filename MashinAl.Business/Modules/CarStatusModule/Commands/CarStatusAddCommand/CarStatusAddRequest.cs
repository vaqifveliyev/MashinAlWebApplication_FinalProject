using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusAddCommand
{
    public class CarStatusAddRequest : IRequest<CarStatus>
    {
        public string Title { get; set; }
    }
}
