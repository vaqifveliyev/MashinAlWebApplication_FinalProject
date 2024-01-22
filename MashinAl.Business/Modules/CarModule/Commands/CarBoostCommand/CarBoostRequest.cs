using MashinAl.Infastructure.Entities;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarBoostCommand
{
    public class CarBoostRequest : IRequest<Car>
    {
        public int Id { get; set; }
        public bool IsBoosted { get; set; }

    }
}
